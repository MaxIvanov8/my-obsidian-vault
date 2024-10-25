Метод **Parallel.ForEach** осуществляет итерацию по коллекции, реализующей интерфейс IEnumerable, подобно циклу foreach, только осуществляет параллельное выполнение перебора.

ParallelLoopResult ForEach<TSource>(IEnumerable<TSource> source,Action<TSource> body)

На выходе метод возвращает структуру ParallelLoopResult, которая содержит информацию о выполнении цикла.

ParallelLoopResult result = Parallel.ForEach<int>(
        new List<int>() { 1, 3, 5, 8 },
       Square);

// вычисляем квадрат числа
void Square(int n)
`{`
    `Console.WriteLine($"Выполняется задача {Task.CurrentId}");
    `Console.WriteLine($"Квадрат числа {n} равен {n * n}"``);`
    `Thread.Sleep(2000);`
`}`

`ParallelLoopResult result = Parallel.ForEach<``int``>(`

       `new` `List<``int``>() { 1, 3, 5, 8 },`

       `Square`

`);`

`// вычисляем квадрат числа`

`void` `Square(``int` `n)`

`{`

    `Console.WriteLine($``"Выполняется задача {Task.CurrentId}"``);`

    `Console.WriteLine($``"Квадрат числа {n} равен {n * n}"``);`

    `Thread.Sleep(2000);`

`}`


