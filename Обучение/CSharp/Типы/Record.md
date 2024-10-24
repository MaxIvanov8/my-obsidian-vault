Records представляют новый ссылочный тип, который появился в C#9. Ключевая особенность records состоит в том, что они могут представлять неизменяемый (immutable) тип, который по умолчанию обладает рядом дополнительных возможностей по сравнению с классами и структурами. **Такие типы более безопасны в тех ситуациях, когда нам надо гарантировать, что данные объекта не будут изменяться**.

Для определения records используется ключевое слово record. Если определяется класс record, то ключевое слово `class` можно не использовать при определении типа:

`public` `record Person`
`{`
    `public` `string` `Name {` `get;` `set; }`
    `public` `Person(string` `name) => Name = name;`
`}`

При определении структуры record при объявлении типа надо использовать ключевое слово struct:

`public` `record` `struct` `Person`
`{`
    `public` `string` `Name {` `get;` `set; }`
    `public` `Person(string` `name) => Name = name;`
`}`

Хотя типы record предназначены для создания неизменяемых типов, однако одно только применение ключевого слова record не гарантирует неизменяемость объектов record. Они являются неизменяемыми (immutable) только при определенных условиях. Например, мы можем написать так:

`var person =` `new` `Person("Tom");`
`person.Name =` `"Bob";`
`Console.WriteLine(person.Name);` `// Bob - данные изменились`

`public` `record Person`
`{`
    `public` `string` `Name {` `get;` `set; }`
    `public` `Person(string` `name) => Name = name;`
`}`

Чтобы сделать его действительно неизменяемым, для свойств вместо обычных сеттеров надо использовать модификатор **init**.

`var person =` `new` `Person("Tom");`
`person.Name =` `"Bob";`    `// ! ошибка - свойство изменить нельзя`

`public` `record Person`
`{`
    `public` `string` `Name {` `get; init; }`
    `public` `Person(string` `name) => Name = name;`
`}`

Во многим records похожи на обычные классы и структуры, например, они могут абстрактными, их также можно наследовать либо запрещать наследование с помощью оператора sealed. Тем не менее есть и ряд отличий. Рассмотрим некоторые основные отличия records от стандартных классов и структур.

### Сравнение на равенство

При определении record компилятор генерирует метод **Equals()** для сравнения с другим объектом. При этом сравнение двух records производится на основе их значений. Например, рассмотрим следующий пример:

`var person1 =` `new` `Person("Tom");`
`var person2 =` `new` `Person("Tom");`
`Console.WriteLine(person1.Equals(person2));` `// true`

`public` `record Person`
`{`
    `public` `string` `Name {` `get; init; }`
    `public` `Person(``string` `name) => Name = name;`
`}`

Кроме того, для record уже по умолчанию реализованы операторы == и !=, которые также сравнивают две record по значению:

`var person1 =` `new` `Person("Tom");`
`var person2 =` `new` `Person("Tom");`
`Console.WriteLine(person1 == person2);` `// true`

### Оператор with

В отличие от классов records поддерживают инициализацию с помощью оператора with. Он позволяет создать одну record на основе другой record:

`var tom =` `new` `Person("Tom", 37);`
`var sam = tom with { Name =` `"Sam"` `};`
`Console.WriteLine($"{sam.Name} - {sam.Age}");` `// Sam - 37`

`public` `record Person`
`{`
    `public` `string` `Name {` `get; init; }`
    `public` `int` `Age {` `get; init; }`
    `public` `Person(string` `name,` `int` `age)`
    `{`
        `Name = name; Age = age;`
    `}`
`}`

### Позиционные records

Records могут принимать данные для свойств через конструктор, и в этом случае мы можем сократить их определение. Например, пусть у нас есть следующая record Person:

`public` `record Person`
`{`
    `public` `string` `Name {` `get; init; }`
    `public` `int` `Age {` `get; init; }`
    `public` `Person(string` `name,` `int` `age)`
    `{`
        `Name = name; Age = age;`
    `}`
    `public` `void` `Deconstruct(out` `string` `name,` `out` `int` `age) => (name, age) = (Name, Age);`
`}`

Кроме конструктора здесь реализован деконструктор, который позволяет разложить объект Person на кортеж значений. И мы могли бы применить ее, например, следующим образом:

`var person =` `new` `Person ("Tom", 37);`
`Console.WriteLine(person.Name);` `// Tom`
`var (personName, personAge) = person;`
`Console.WriteLine(personAge);`     `// 37`
`Console.WriteLine(personName);`    `// Tom`

Выше определенную record Person можно сократить до позиционной record и результат будет таким же.

### Позиционные структуры для чтения

Следует отметить различие между позиционными классами и структурами record. Свойства класса record, которые устанавливаются через параметры конструктора, по умолчанию будут иметь модификатор **init**. То есть после установки их значений через конструктор, мы больше не сможем их изменить:


`var person =` `new` `Person("Tom", 37);`
`person.Name =` `"Bob";`    `// ! Ошибка - значение нельзя изменить`
`public` `record Person(string` `Name,` `int` `Age);`

Стоит отметить, что это относится только к тем свойствам, которые устанавливаются через конструктор.
Однако для позиционных структур record свойства будут иметь стандартные сеттеры, которые позволят изменять значения свойств:

`var person =` `new` `Person("Tom", 37);`
`person.Name =` `"Bob";`
`Console.WriteLine(person.Name);` `// Bob - значение изменилось`
`// структура record`
`public` `record` `struct` `Person(string` `Name,` `int` `Age);`

Чтобы для подобных свойств структуры record использовался модификатор **init** вместо обычных сеттеров, такую структуру надо определить с ключевым словом **readonly**:

`var person =` `new` `Person("Tom", 37);`
`person.Name =` `"Bob";`    `// ! Ошибка - значение свойства нельзя изменить`
`// структура record доступна только для чтения`
`public` `readonly` `record` `struct` `Person(string` `Name,` `int` `Age);`

### ToString

Небольшим преимуществом типов record также является то, что для них уже по умолчанию реализован метод ToString(), который выводит состояние объекта в отформатированном виде:

`var person =` `new` `Person("Tom", 37);`
`Console.WriteLine(person);` `// Person {Name = Tom, Age = 37}`


### Наследование

Как и обычные классы record-классы могут наследоваться:

`public` `record Person(string` `Name,` `int` `Age);`
`public` `record Employee(string` `Name,` `int` `Age,` `string` `Company) : Person(Name, Age);`

### Преимущества

1. использование в качестве ключа в словаре: каждый раз, когда вам нужен словарь по двум параметрам, приходится или использовать кортежи, или использовать анонимные типы, или писать свой класс с методами Equals и GetHashCode, причем использовать кортежи в публичном API - дурной тон, а анонимные типы так и вовсе приводят к нетипизированному ключу;
2. кеширование данных: данные в кеше обязаны быть неизменяемыми, чего можно достигнуть или защитным копированием - или иммутабельностью;
3. многопоточный доступ: к иммутабельным данным можно обращаться из любых потоков без блокировок.