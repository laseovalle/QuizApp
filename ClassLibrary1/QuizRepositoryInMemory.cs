using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLibrary
{
    public class QuizRepositoryInMemory : IQuizRepository
    {
        private List<Question> _questionList = new List<Question>();
        private static Random _randy = new Random();
        private static int nextId = 0;

        public List<Question> GetQuestions()
        {
            return _questionList;
        }

        public List<Question> GetQuestions(int maxNumberofQuestions)
        {
            if (_questionList.Count == 0)
            {
                return _questionList;
            }
            List<Question> returnList = new List<Question>();

            for (int i = 0; i < maxNumberofQuestions; i++)
            {
                int myRandomNumber = _randy.Next(0, _questionList.Count - 1);
                returnList.Add(_questionList[myRandomNumber]);
            }


            return returnList;
        }

        public Question GetQuestionById(int id)
        {
            return _questionList.Find(question => question.QuestionId == id);
        }

        public void UpdateQuestion(Question updateQuestion)
        {
            _questionList.RemoveAll(question => question.QuestionId == updateQuestion.QuestionId);
            _questionList.Add(updateQuestion);
        }

        public Question GetQuestion()
        {
            return GetQuestions(1)[0];
        }




        public void AddQuestion(Question newQuestion)
        {
            newQuestion.QuestionId = nextId++;
            _questionList.Add(newQuestion);

        }

        public void DeleteQuestion(int id)
        {
            _questionList.RemoveAll(question => question.QuestionId == id);
        }

        public void LoadSampleQuestions()
        {
            Question q1 = new Question
            {
                Category = "Test Question",
                QuestionType = "Multiple Choice",
                Content = "What color is the sky?",
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        AnswerId = 0,
                        Content = "Red",
                        IsCorrect = false
                    },

                       new Answer
                    {
                        AnswerId = 1,
                        Content = "Blue",
                        IsCorrect = true
                    },

                           new Answer
                    {
                        AnswerId = 2,
                        Content = "Purple",
                        IsCorrect = false
                    },

                               new Answer
                    {
                        AnswerId = 3,
                        Content = "Green",
                        IsCorrect = false
                    },



                }
            };

            AddQuestion(q1);
        }
    }
}
