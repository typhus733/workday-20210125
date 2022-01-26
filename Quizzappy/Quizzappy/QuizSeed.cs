using Quizzappy.Daos;
using Quizzappy.Extensions;
using Quizzappy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzappy
{
    public static class QuizSeed
    {
        public static void InitData(QuizContext context)
        {
            var rnd = new Random();

            var beginningQuestionText = new[] { "What does", "How many", "What is the difference between" };
            var endQuestionText = new[] { "a fox and a bull", "this is totally a real question", "how do I make randomly generated questions"};

            var totalQuestions = 0;
            var totalAnswers = 1;

            context.Quizzes.AddRange(5.Times(x =>
            {
                var quizName = $"Quiz {x,-3:000}";


                var questionLength = rnd.Next(1, 21);
                var multipleChoiceQuestions = new List<MultipleChoiceQuestion>();
                var shortAnswerQuestions = new List<ShortAnswerQuestion>();
                var fillTheBlanksQuestions = new List<FillTheBlanksQuestion>();
                
                for(int i = 0; i < questionLength; i++)
                {
                    var beginningQuestion = beginningQuestionText[rnd.Next(0, 3)];
                    var endQuestion = endQuestionText[rnd.Next(0, 3)];

                    totalQuestions += 1;
                    var typeOfQuestion = rnd.Next(0, 3);
                    switch(typeOfQuestion)
                    {
                        case 0:
                            {
                                var multipleChoiceAnswers = new List<TextAnswer>
                                {
                                    new TextAnswer
                                    {
                                        AnswerId = totalAnswers,
                                        Answer = "A"
                                    },
                                    new TextAnswer
                                    {
                                        AnswerId = totalAnswers + 1,
                                        Answer = "B"
                                    },
                                    new TextAnswer
                                    {
                                        AnswerId = totalAnswers + 2,
                                        Answer = "C"
                                    },
                                    new TextAnswer
                                    {
                                        AnswerId = totalAnswers + 3,
                                        Answer = "D"
                                    },
                                    new TextAnswer
                                    {
                                        AnswerId = totalAnswers + 4,
                                        Answer = "E"
                                    }
                                };

                                totalAnswers += 5;

                                var question = new MultipleChoiceQuestion
                                {
                                    QuestionId = totalQuestions,
                                    QuestionText = beginningQuestion + endQuestion + $"{totalQuestions}",
                                    Answers = multipleChoiceAnswers,
                                    CorrectAnswer = "E",
                                };

                                multipleChoiceQuestions.Add(question);
                                break;
                            }
                        case 1:
                            {
                                var question = new ShortAnswerQuestion
                                {
                                    QuestionId = totalQuestions,
                                    QuestionText = beginningQuestion + endQuestion + $"{totalQuestions}",
                                    WordLimit = 500+5*rnd.Next(0, 100)
                                };

                                shortAnswerQuestions.Add(question);
                                break;
                            }
                        case 2:
                            {
                                var fillTheBlanksAnswers = new List<TextAnswer>()
                                    {
                                        new TextAnswer
                                        {
                                            AnswerId = totalAnswers,
                                            Answer = "true"
                                        },
                                        new TextAnswer
                                        {
                                            AnswerId = totalAnswers+1,
                                            Answer = "false"
                                        }
                                    };

                                totalAnswers += 2;

                                var question = new FillTheBlanksQuestion
                                {
                                    QuestionId = totalQuestions,
                                    QuestionText = beginningQuestion + "_____" + endQuestion  + "_____" + $"{totalQuestions}",
                                    CorrectAnswers = fillTheBlanksAnswers
                                };

                                fillTheBlanksQuestions.Add(question);
                                break;
                            }
                        default: break;

                    }
                }

                return new Quiz()
                {
                    QuizName = quizName,
                    QuizId = x,
                    MultipleChoiceQuestions = multipleChoiceQuestions,
                    ShortAnswerQuestions = shortAnswerQuestions,
                    FillTheBlanksQuestions = fillTheBlanksQuestions
                };
            }));

            context.SaveChanges();
        }
    }
}
