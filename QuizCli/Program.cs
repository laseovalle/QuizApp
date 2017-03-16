using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizLibrary;

namespace QuizCli
{
    class Program
    {
        static void Main(string[] args)
        {
            QuizRepositoryInMemory quizRepo = new QuizRepositoryInMemory();

            quizRepo.AddQuestion(new Question
            {
                QuestionId = 0,
                Category = "test",
                Content = "Select your favorite color",
                Answers = new List<Answer>
                {
                    new Answer {
                        AnswerId =0,
                        Content = "Blue",
                        IsCorrect = false
                    }
                }

            });

            quizRepo.AddQuestion(new Question
            {
                QuestionId = 1,
                Category = "test",
                Content = "Select your favorite number",
                Answers = new List<Answer>
                {
                    new Answer {
                        AnswerId =0,
                        Content = "Blue",
                        IsCorrect = false
                    }
                }

            });

            var resultList = quizRepo.GetQuestions(10);

            if(resultList.Count <= 10)
            {
                Console.WriteLine("Test 1 Passed");
            } else
            {
                Console.WriteLine("Test 1 Failed");
            }

            var testQuestion = quizRepo.GetQuestionById(1);

            if(testQuestion.Content == "Select your favorite number")
            {
                Console.WriteLine("Test 2 Passed");
            }
            else
            {
                Console.WriteLine("Test 2 Failed");
            }

            var singleQuestion = quizRepo.GetQuestion();
            if (!string.IsNullOrWhiteSpace(singleQuestion.Content))
            {
                Console.WriteLine("Test 3 Passed");
            }
            else
            {
                Console.WriteLine("Test 3 Failed");
            }
        }
    }
}
