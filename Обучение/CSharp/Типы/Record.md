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

