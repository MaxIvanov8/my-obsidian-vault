Метод Parallel.For позволяет выполнять итерации цикла параллельно. Он имеет следующее определение:
`For(int,` `int, Action<int>)`

Первый параметр метода задает начальный индекс элемента в цикле, а второй параметр - конечный индекс. Третий параметр - делегат Action - указывает на метод, который будет выполняться один раз за итерацию:

`Parallel.For(1, 5, Square);`
`// вычисляем квадрат числа`

`void` `Square(int` `n)`
`{`
    `Console.WriteLine($"Выполняется задача {Task.CurrentId}");`
    `Console.WriteLine($"Квадрат числа {n} равен {n * n}");`
    `Thread.Sleep(2000);`
`}`

`ParallelLoopResult result = Parallel.ForEach<``int``>(`
       `new` `List<``int``>() { 1, 3, 5, 8 },`
       `Square``);`

`// вычисляем квадрат числа`

`void` `Square(``int` `n)`

`{`

    `Console.WriteLine($``"Выполняется задача {Task.CurrentId}"``);`

    `Console.WriteLine($``"Квадрат числа {n} равен {n * n}"``);`

    `Thread.Sleep(2000);`

`}`