using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiguresClassLibrary;

namespace TaskClassLibrary
{
    
    public class Box<T> : IEnumerable<T>
    {

        /// <summary>
        /// Коллекция хранимых данных.
        /// </summary>
        private List<T> _items = new List<T>();


        /// <summary>
        /// Количество элементов.
        /// </summary>
        public int Count => _items.Count;

        /// <summary>
        /// Добавить данные во множество.
        /// </summary>
        /// <param name="item"> Добавляемые данные. </param>
        public void Add(T item)
        {
            // Проверяем входные данные на пустоту.
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            // Множество может содержать только уникальные элементы,
            // поэтому если множество уже содержит такой элемент данных, то не добавляем его.
            if (!_items.Contains(item))
            {
                _items.Add(item);
            }
        }

        /// <summary>
        /// Удалить элемент из множества.
        /// </summary>
        /// <param name="item"> Удаляемый элемент данных. </param>
        public void Remove(T item)
        {
            // Проверяем входные данные на пустоту.
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            // Если коллекция не содержит данный элемент, то мы не можем его удалить.
            if (!_items.Contains(item))
            {
                throw new KeyNotFoundException($"Элемент {item} не найден в множестве.");
            }

            // Удаляем элемент из коллекции.
            _items.Remove(item);
        }

        /// <summary>
        /// Вернуть перечислитель, выполняющий перебор всех элементов множества.
        /// </summary>
        /// <returns> Перечислитель, который можно использовать для итерации по коллекции. </returns>
        public IEnumerator<T> GetEnumerator()
        {
            // Используем перечислитель списка элементов данных множества.
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // Используем перечислитель списка элементов данных множества.
            return _items.GetEnumerator();
        }
    }
}
