PGP (англ. Pretty Good Privacy) — компьютерная программа, также библиотека функций, позволяющая выполнять операции шифрования и цифровой подписи сообщений, файлов и другой информации, представленной в электронном виде, в том числе прозрачное шифрование данных на запоминающих устройствах, например, на жёстком диске.

Первоначально разработана Филиппом Циммерманном в 1991 году.

PGP имеет множество реализаций, совместимых между собой и рядом других программ ([GnuPG](https://ru.wikipedia.org/wiki/GnuPG "GnuPG"), FileCrypt и др.) благодаря стандарту [OpenPGP](https://ru.wikipedia.org/wiki/OpenPGP "OpenPGP") ([RFC 4880](https://tools.ietf.org/html/rfc4880)), но имеющих разный набор функциональных возможностей.

Шифрование PGP осуществляется последовательно хешированием, сжатием данных, шифрованием с симметричным ключом, и, наконец, шифрованием с открытым ключом, причём каждый этап может осуществляться одним из нескольких поддерживаемых алгоритмов. Симметричное шифрование производится с использованием одного из семи симметричных алгоритмов (AES, CAST5, 3DES, IDEA, Twofish, Blowfish, Camellia) на сеансовом ключе. Сеансовый ключ генерируется с использованием криптографически стойкого генератора псевдослучайных чисел. Сеансовый ключ зашифровывается открытым ключом получателя с использованием алгоритмов RSA или Elgamal (в зависимости от типа ключа получателя).

Для первичного анализа пакета можно использовать утилиту pgpdump, которая анализирует открытые параметры пакеты.

### Структура заголовка пакета

Есть два формата: старый и новый. Здесь рассматривается старый.
Пример:
8C 0D 04 09 03 08 AC 45 B2 BF 5F F1 32 35

Первый байт 8С - 10001100
Bit 7 -- Always one
Bit 6 -- New packet format if set
Bits 5-2 -- packet tag
Bits 1-0 -- length-type

6 бит - 0 – старый формат;
5-2 бит – 0011 – packet tag(3) Symmetric-Key Encrypted Session Key Packet – показывает, что содержит тело пакета;
1-0 бит – 00 – тип длины заголовка – 1 байт

0D – длина заголовка (13 байт)

04 -  A one-octet version number.  The only currently defined version is 4.

09 – тип шифрования(AES-256)

03 - string-to-key (S2K)

08 – хэш-алгоритм (SHA256)

AC 45 B2 BF 5F F1 32 35 - соль

#### Типы шифрования

```
typedef enum
  {
    CIPHER_ALGO_NONE        =  0,
    CIPHER_ALGO_IDEA        =  1,
    CIPHER_ALGO_3DES        =  2,
    CIPHER_ALGO_CAST5       =  3,
    CIPHER_ALGO_BLOWFISH    =  4, /* 128 bit */
    /* 5 & 6 are reserved */
    CIPHER_ALGO_AES         =  7,
    CIPHER_ALGO_AES192      =  8,
    CIPHER_ALGO_AES256      =  9,
    CIPHER_ALGO_TWOFISH     = 10, /* 256 bit */
    CIPHER_ALGO_CAMELLIA128 = 11,
    CIPHER_ALGO_CAMELLIA192 = 12,
    CIPHER_ALGO_CAMELLIA256 = 13
  }
cipher_algo_t;
```
### Типы хэширования

```
typedef enum
  {
    DIGEST_ALGO_MD5         =  1,
    DIGEST_ALGO_SHA1        =  2,
    DIGEST_ALGO_RMD160      =  3,
    /* 4, 5, 6, and 7 are reserved. */
    DIGEST_ALGO_SHA256      =  8,
    DIGEST_ALGO_SHA384      =  9,
    DIGEST_ALGO_SHA512      = 10,
    DIGEST_ALGO_SHA224      = 11,
    DIGEST_ALGO_PRIVATE10   = 110
  }
digest_algo_t;
```