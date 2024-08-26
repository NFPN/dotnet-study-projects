using System.Speech.Recognition;

internal class Program
{
    private static void Main(string[] args)
    {
        // Create an in-process speech recognizer for the en-US locale.
        using SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));

        // Create and load a dictation grammar.
        recognizer.LoadGrammar(new DictationGrammar());
        // Add a handler for the speech recognized event.
        recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Recognizer_SpeechRecognized);

        // Configure input to the speech recognizer.
        recognizer.SetInputToDefaultAudioDevice();

        // Start asynchronous, continuous speech recognition.
        recognizer.RecognizeAsync(RecognizeMode.Multiple);

        // Keep the console window open.
        while (true)
        {
            Console.ReadLine();
        }
    }

    private static void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        Console.WriteLine($"You said: {e.Result.Text}");
    }
}