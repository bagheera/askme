﻿using System;

namespace Askme.Domain
{
    public class QuestionVote:Vote
    {
        protected QuestionVote(){}
        private QuestionVote(User user, int value) : base(user, value)
        {
        }

        public static QuestionVote PositiveVote(User user)
        {
            var vote = new QuestionVote(user, PositiveValue);
            return vote;
        }

        public static QuestionVote NegativeVote(User user)
        {
            var vote = new QuestionVote(user, NegativeValue);
            return vote;
        }
    }
}