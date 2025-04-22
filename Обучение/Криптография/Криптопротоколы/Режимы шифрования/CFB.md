**Режим обратной связи по шифротексту**, **режим гаммирования с обратной связью** (Cipher Feedback Mode, CFB) — один из вариантов использования симметричного блочного шифра, при котором для шифрования следующего блока открытого текста он складывается по модулю 2 с перешифрованным (блочным шифром) результатом шифрования предыдущего блока.

Шифрование может быть описано следующим образом:

![{\displaystyle C_{0}=IV}](https://wikimedia.org/api/rest_v1/media/math/render/svg/7b8cee079a821cf0a25744655bd839d122716b73)

![{\displaystyle C_{i}=E_{k}\left(C_{i-1}\right)\oplus P_{i}}](https://wikimedia.org/api/rest_v1/media/math/render/svg/c30927935e7052468688c739617cfcab15a89763)

![{\displaystyle P_{i}=E_{k}\left(C_{i-1}\right)\oplus C_{i}}](https://wikimedia.org/api/rest_v1/media/math/render/svg/e8fb551d4db59f01ed0480467d6d233492a503fd)

где ![{\displaystyle i}](https://wikimedia.org/api/rest_v1/media/math/render/svg/add78d8608ad86e54951b8c8bd6c8d8416533d20) — номера блоков, ![{\displaystyle IV}](https://wikimedia.org/api/rest_v1/media/math/render/svg/05e02bc314180f8770fd135cd0e80ac4835a676d) — вектор инициализации (синхропосылка), ![{\displaystyle C_{i}}](https://wikimedia.org/api/rest_v1/media/math/render/svg/cc49dc02c0ec8c86b67e7d10518ac791eda0bf22) и ![{\displaystyle P_{i}}](https://wikimedia.org/api/rest_v1/media/math/render/svg/3ba1396129f7be3c7f828a571b6649e6807d10d3) — блоки зашифрованного и открытого текстов соответственно, а ![{\displaystyle E_{k}}](https://wikimedia.org/api/rest_v1/media/math/render/svg/7587849b44d775263271e89499f4327eeac5dc81) — функция блочного шифрования.