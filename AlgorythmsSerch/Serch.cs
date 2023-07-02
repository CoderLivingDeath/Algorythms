namespace AlgorythmsSerch
{
    public static class Search
    {
        public static int BinarySearch(int[] array, int searchedValue, int first, int last)
        {
            //границы сошлись
            if (first > last)
            {
                //элемент не найден
                return -1;
            }

            //средний индекс подмассива
            var middle = (first + last) / 2;
            //значение в средине подмассива
            var middleValue = array[middle];

            if (middleValue == searchedValue)
            {
                return middleValue;
            }
            else
            {
                if (middleValue > searchedValue)
                {
                    //рекурсивный вызов поиска для левого подмассива
                    return BinarySearch(array, searchedValue, first, middle - 1);
                }
                else
                {
                    //рекурсивный вызов поиска для правого подмассива
                    return BinarySearch(array, searchedValue, middle + 1, last);
                }
            }
        }

        public static int BinarySearchIterat(int[] array, int searchedValue, int left, int right)
        {
            //пока не сошлись границы массива
            while (left <= right)
            {
                //индекс среднего элемента
                var middle = (left + right) / 2;

                if (searchedValue == array[middle])
                {
                    return middle;
                }
                else if (searchedValue < array[middle])
                {
                    //сужаем рабочую зону массива с правой стороны
                    right = middle - 1;
                }
                else
                {
                    //сужаем рабочую зону массива с левой стороны
                    left = middle + 1;
                }
            }
            //ничего не нашли
            return -1;
        }

        public static int LinearSearch(int[] array, int value)
        {
            foreach (var item in array)
            {
                if(item == value)
                {
                    return value;
                }
            }
            return -1;
        }
    }
}