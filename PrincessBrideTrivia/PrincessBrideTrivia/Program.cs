using System;
using System.IO;
// This all exists in a PBT Namespace
namespace PrincessBrideTrivia
{
    // We have a program object
    public class Program
    {
        // The main class 
        public static void Main(string[] args)
        {
            // First we obtain the file path
            string filePath = GetFilePath();

            // Second we load the questions in an array from the file 
            Question[] questions = LoadQuestions(filePath);

            // We init # of correct to 0 
            int numberCorrect = 0;

            // We loop through each question 
            for (int i = 0; i < questions.Length; i++)
            {
                // Asks the question and obtains whether the result is correct
                bool result = AskQuestion(questions[i]);
                // If it's correct, it increments the # of correct answers 
                if (result)
                {
                    numberCorrect++;
                }
            }
            // Outputs the percentage of answers that are correct
            Console.WriteLine($"You got {GetPercentCorrect(numberCorrect, questions.Length)} correct");
        }
        // Uses an equation to get the percentage of the correct # of answers
        public static string GetPercentCorrect(double numberCorrectAnswers, double numberOfQuestions)
        {
            return (int)((numberCorrectAnswers / numberOfQuestions) * 100) + "%";
        }

        // Asks the question to a user
        public static bool AskQuestion(Question question)
        {
            // First displays a question
            DisplayQuestion(question);

            // Receives a Guess from a user
            string userGuess = GetGuessFromUser();

            // Displays the result of the user guess
            return DisplayResult(userGuess, question);
        }

        // Reads the console to obtain the guess
        public static string GetGuessFromUser()
        {
            return Console.ReadLine();
        }

        // Displays the result  of the guess
        public static bool DisplayResult(string userGuess, Question question)
        {
            // If the user's guess is equal to the correct answer's index it tells them they're correct
            if (userGuess == question.CorrectAnswerIndex)
            {
                Console.WriteLine("Correct");
                return true;
            }
            // Otherwise tells the user that it is false
            Console.WriteLine("Incorrect");
            return false;
        }

        // Display Question is where it breaks and it is because the question object is null 
        public static void DisplayQuestion(Question question)
        {
            Console.WriteLine("Question: " + question.Text);
            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + question.Answers[i]);
            }
        }

        public static string GetFilePath()
        {
            return "Trivia.txt";
        }
        
        // Load questions must not be working correctly 
        public static Question[] LoadQuestions(string filePath)
        {
            // Reads all of the lines from the filepath 
            string[] lines = File.ReadAllLines(filePath);

           
            // The Array of Questions  
            Question[] questions = new Question[lines.Length / 5];
            for (int i = 0; i < questions.Length; i++)
            {
                // Sets the line index to the next question each time, each question is 5 lines 
                int lineIndex = i * 5;
                string questionText = lines[lineIndex];
                // First answer is line 1, and thus forth 
                string answer1 = lines[lineIndex + 1];
                string answer2 = lines[lineIndex + 2];
                string answer3 = lines[lineIndex + 3];

                string correctAnswerIndex = lines[lineIndex + 4];

                Question question = new Question();
                question.Text = questionText;
                question.Answers = new string[3];
                question.Answers[0] = answer1;
                question.Answers[1] = answer2;
                question.Answers[2] = answer3;
                question.CorrectAnswerIndex = correctAnswerIndex;

                questions[i] = question; 
            }
            return questions;
        }
    }
}
