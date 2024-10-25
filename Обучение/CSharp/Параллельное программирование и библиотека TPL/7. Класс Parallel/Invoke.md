`// метод Parallel.Invoke выполняет три метода`
`Parallel.Invoke(`
    `Print,`
    `() =>`
    `{`
        `Console.WriteLine($"Выполняется задача {Task.CurrentId}");`
        `Thread.Sleep(3000);`
    `},`
    `() => Square(5)`
`);`

`void` `Print()`
`{`
    `Console.WriteLine($"Выполняется задача {Task.CurrentId}");`
    `Thread.Sleep(3000);`
`}`

`// вычисляем квадрат числа`
`void` `Square(int` `n)`
`{`
    `Console.WriteLine($"Выполняется задача {Task.CurrentId}");`
    `Thread.Sleep(3000);`
    `Console.WriteLine($"Результат {n * n}");`
`}`

Метод `Parallel.Invoke` в качестве параметра принимает массив объектов `Action`, то есть мы можем передать в данный метод набор методов, которые будут вызываться при его выполнении.