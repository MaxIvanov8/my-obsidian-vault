Метод **Parallel.ForEach** осуществляет итерацию по коллекции, реализующей интерфейс IEnumerable, подобно циклу foreach, только осуществляет параллельное выполнение перебора.

ParallelLoopResult ForEach<TSource>(IEnumerable<TSource> source,Action<TSource> body)

