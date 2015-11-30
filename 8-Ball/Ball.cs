using System;
using System.Collections.Generic;
using System.Linq;
using CollectionMtLib;
using Support;
using Support.Interfaces;

namespace _8_Ball
{
    public class Ball : IPlugin
    {

        #region Info

        private readonly Version _version = new Version(0, 0, 0, 1);
        private readonly char[] _symbols = {'q', 'й'};

        public string PluginName
        {
            get { return "Magic Ball"; }
        }

        public string DisplayPluginName
        {
            get { return "8-Ball"; }
        }

        public string PluginDescription
        {
            get { return "Плагин для ответов на вопросы"; }
        }

        public string Author
        {
            get { return "Stars"; }
        }

        public Version Version
        {
            get { return _version; }
        }

        #endregion

        private readonly Random _rand = new Random();
        private readonly List<Answer> _answers = new List<Answer>();

        //счетчики
        private int _temp;

        //конструктор
        public Ball()
        {
            foreach (var q in _positive.Select(st => new Answer(MessageType.Positive, st)))
            {
                _answers.Add(q);
            }

            foreach (var q in _halfPositive.Select(st => new Answer(MessageType.HalfPositive, st)))
            {
                _answers.Add(q);
            }

            foreach (var q in _neutral.Select(st => new Answer(MessageType.Neutral, st)))
            {
                _answers.Add(q);
            }

            foreach (var q in _negative.Select(st => new Answer(MessageType.Negative, st)))
            {
                _answers.Add(q);
            }
        }

        //Ответ
        private void GetAnswer()
        {
            _temp = _rand.Next(0, _answers.Count - 1);
           //Collection.Add(new Result(_answers[_temp].Message,"","",));
        }

        //получение строки из консоли
        private void PutString(string str)
        {
            try
            {
                if (IsAnswer(str))
                {
                    GetAnswer();
                }
            }
            catch
            {
                //if (SendMessage != null)
                //{
                //    SendMessage("Спросите меня о чем-либо. Я на все знаю ответ");
                //}
            }
        }

        //проверка последнего символа
        private static bool IsAnswer(string str)
        {
            var array = str.ToCharArray();
            return array[array.Length - 1] == '?';
        }

        #region варианты ответов

        private readonly string[] _positive =
        {
            "It is certain (Бесспорно)",
            "It is decidedly so (Решено)",
            "Without a doubt (Никаких сомнений)",
            "Yes — definitely (Определённо да)",
            "You may rely on it (Можешь быть уверен в этом)"
        };

        private readonly string[] _halfPositive =
        {
            "As I see it, yes (Мне кажется — «да»)",
            "Most likely (Вероятнее всего)",
            "Outlook good (Хорошие перспективы)",
            "Signs point to yes (Знаки говорят — «да»)",
            "Yes (Да)"
        };

        private readonly string[] _neutral =
        {
            "Reply hazy, try again (Пока не ясно, попробуй снова)",
            "Ask again later (Спроси позже)",
            "Better not tell you now (Лучше не рассказывать)",
            "Cannot predict now (Сейчас нельзя предсказать)",
            "Concentrate and ask again (Сконцентрируйся и спроси опять)"
        };

        private readonly string[] _negative =
        {
            "Don’t count on it (Даже не думай)",
            "My reply is no (Мой ответ — «нет»)",
            "My sources say no (По моим данным — «нет»)",
            "Outlook not so good (Перспективы не очень хорошие)"
        };

        #endregion

        public IEnumerable<char> Symbols
        {
            get
            {
                return _symbols;
            }
        }

        public CollectionMtWithAsyncObservableCollectionReadOnlyCopy<Result> Collection { get; set; }
        public void HintChanged(string input)
        {
            //throw new NotImplementedException();
            PutString(input);
        }

        public void Action(string input)
        {

        }

        public event Action<IEnumerable<Result>> Response;
    }
}