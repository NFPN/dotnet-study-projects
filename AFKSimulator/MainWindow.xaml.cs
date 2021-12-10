using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace AFKSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer timer = new();
        private readonly InputSimulator simulator = new();
        private IntPtr currentWindow = IntPtr.Zero;
        public bool isRunning;

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public MainWindow()
        {
            InitializeComponent();
            
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var rand = new Random();

            if (ushort.TryParse(txtBoxRange.Text, out var result))
                timer.Interval = new TimeSpan(0, 0, rand.Next(1, result));
            else
                timer.Interval = new TimeSpan(0, 0, rand.Next(1, 60));

            if (isRunning)
                RunSimulation();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            currentWindow = GetForegroundWindow();
            isRunning = !isRunning;
            ButtonStart.Content = isRunning ? "Stop" : "Start";
        }

        private void RunSimulation()
        {
            var window = GetWindow("FINAL FANTASY XIV");

            if (window == IntPtr.Zero)
                return;

            _ = ShowWindow(window, ShowWindowEnum.ShowNoActivate);
            _ = SetForegroundWindow(window);

            var keys = new List<VirtualKeyCode>
            {
                VirtualKeyCode.ESCAPE,
            };

            _ = simulator.Keyboard.KeyPress(GetRandomKey(keys));

            if (checkSwitch.IsChecked.GetValueOrDefault())
            {
                _ = ShowWindow(currentWindow, ShowWindowEnum.ShowNoActivate);
                _ = SetForegroundWindow(currentWindow);
            }
        }

        public static IntPtr GetWindow(string wName)
        {
            foreach (Process pList in Process.GetProcesses())
                if (pList.MainWindowTitle.Contains(wName))
                    return pList.MainWindowHandle;

            return IntPtr.Zero;
        }

        public VirtualKeyCode GetRandomKey(IEnumerable<VirtualKeyCode> virtualKeys)
            => virtualKeys.OrderBy(e => Guid.NewGuid()).FirstOrDefault();
    }
}
