using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovChains
{
    public class State
    {
        // Генератор случайных чисел.
        // Инициализируем секундами
        Random r = new Random(DateTime.Now.Millisecond);
        // Здесь будут хранится состояния, в которые мы будем переходить и их интегральные вероятности
        Dictionary<State, float> Dic = new Dictionary<State, float>();
        // Сколько в этом состоянии сейчас находится элементов
        public int Count = 0;
        /// <summary>
        /// Новая итерация и новый месяц в компании
        /// </summary>
        public void Next()
        {
            for (int i = 0; i < Count; i++)
            {
                float rnd = (float)r.NextDouble();
                foreach (var item in Dic)
                {
                    if (rnd < item.Value)
                    {
                        item.Key.Count++;
                        Count--;
                        break;
                    }
                }
            }
        }

        public void Add(State s, float prob)
        {
            // Получаем из обычной вероятности, интегральную
            float c = (Dic.Count == 0) ? 0 : Dic.ToList()[Dic.Count - 1].Value;
            Dic.Add(s, c + prob);
        }
    }
}
