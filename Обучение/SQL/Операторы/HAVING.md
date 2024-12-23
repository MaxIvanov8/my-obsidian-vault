Фильтрует значения, полученные в результате группировки — то есть работает не с новыми полями, а с результатом вычислений. Его записывают после `GROUP BY`.
```
SELECT connection_area, AVG(age) 
FROM buyer 
WHERE company_marker = 0 
GROUP BY connection_area 
HAVING AVG(age) > 30;
```
Разница между `WHERE` и `HAVING`: `WHERE` работает с исходными данными, `HAVING` — с результатом группировки.