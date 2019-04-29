using System;
using System.Text.RegularExpressions;

namespace Pig_Latin
{
  class Program
  {
    static void Main(string[] args)
    {
      bool userStillTranslating = true;
      Console.WriteLine("Welcome to the Pig Latin Translator!");
      Console.WriteLine();
      while (userStillTranslating)
      {
        Console.Write("Enter a line to be translated: ");
        string userInput = Console.ReadLine();

        Console.WriteLine(TranslateSentenceToPigLatin(userInput));
        
        Console.WriteLine();
        userStillTranslating = Continue("Continue Translating? y/n");
      }
    }

    private static string[] SplitSentence(string sentence)
    {
      return sentence.Split(' ');
    }
    public static string TranslateSentenceToPigLatin(string sentence)
    {
      string[] wordArray = SplitSentence(sentence);
      sentence = "";
      foreach (string item in wordArray)
      {
        sentence += TranslateWordToPigLatin(item) + " ";
      }

      return sentence;
    }
    public static string TranslateWordToPigLatin(string word)
    {
      if (Regex.IsMatch(word, @"^[a-zA-Z]+$"))
      {
        char[] vowelsLower = { 'a', 'e', 'i', 'o', 'u' };
        string[] res = Regex.Split(word, "[aeiouAEIOU]");

        foreach (char letter in vowelsLower)
        {
          if (word[0] == letter)
          {
            return word + "way";
          }
        }

        return word.Substring(res[0].Length) + res[0] + "ay";
      }
      else
      {
        return word;
      }
    }

    public static bool Continue(string message)
    {
      Console.WriteLine(message);
      string input = Console.ReadLine().Trim().ToLower();
      bool run = false;

      if (input == "n" || input == "no")
      {
        Console.WriteLine("Good bye");
        run = false;
      }
      else if (input == "y" || input == "yes")
      {
        run = true;
      }
      else
      {
        Console.WriteLine("I don't understand. Try again!");
        run = Continue(message);
      }
      return run;
    }
  }
}
