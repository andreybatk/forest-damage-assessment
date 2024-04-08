DROP TABLE IF EXISTS TaxPricesExtra;
CREATE TABLE TaxPricesExtra 
(
    ID INT IDENTITY (1, 1) NOT NULL,
    SubjectRF	NVARCHAR(60),
    TreeCessationOfGrowth	NVARCHAR(40),
    TreeWithoutCessationOfGrowth NVARCHAR(40),
    BushCessationOfGrowth	NVARCHAR(40),
    BushWithoutCessationOfGrowth NVARCHAR(40)
);

INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Адыгея', '14562.00', '2912.40', '495.10', '233.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Алтай', '8244.00', '1648.80', '280.30', '131.90');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Башкортостан', '8100.00', '1620.00', '275.40', '129.60');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Бурятия', '3280.00', '656.00', '111.50', '52.50');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Дагестан', '14562.00', '2912.40', '495.10', '233.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Ингушетия', '14562.00', '2912.40', '495.10', '233.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Кабардино-Балкарская Республика', '14562.00', '2912.40', '495.10', '233.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Калмыкия', '14562.00', '2912.40', '495.10', '233.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Карачаево-Черкесская Республика', '14562.00', '2912.40', '495.10', '233.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Карелия', '12348.00', '2469.60', '419.80', '197.60');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Коми', '5190.00', '1038.00', '176.50', '83.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Крым и г. Севастополь', '14562.00', '2912.40', '495.10', '233.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Марий Эл', '10782.00', '2156.40', '366.60', '172.50');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Мордовия', '10782.00', '2156.40', '366.60', '172.50');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Саха (Якутия)', '2050.00', '410.00', '69.70', '32.80');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Северная Осетия - Алания', '14562.00', '2912.40', '495.10', '233.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Татарстан', '10782.00', '2156.40', '366.60', '172.50');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Тыва', '4110.00', '822.00', '139.70', '65.80');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Удмуртская Республика', '8560.00', '1712.00', '291.00', '137.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Республика Хакасия', '7380.00', '1476.00', '250.90', '118.10');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Чеченская Республика', '14562.00', '2912.40', '495.10', '233.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Чувашская Республика', '11124.00', '2224.80', '378.20', '178.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Алтайский край', '8244.00', '1648.80', '280.30', '131.90');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Забайкальский край', '2880.00', '576.00', '97.90', '46.10');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Камчатский край', '3690.00', '738.00', '125.50', '59.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Краснодарский край', '14562.00', '2912.40', '495.10', '233.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Красноярский край', '4110.00', '822.00', '139.70', '65.80');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Пермский край', '5320.00', '1064.00', '180.90', '85.10');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Приморский край', '8856.00', '1771.20', '301.10', '141.70');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Ставропольский край', '14562.00', '2912.40', '495.10', '233.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Хабаровский край', '7038.00', '1407.60', '239.30', '112.60');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Амурская область', '6642.00', '1328.40', '225.80', '106.30');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Архангельская область', '8172.00', '1634.40', '277.80', '130.80');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Астраханская область', '14562.00', '2912.40', '495.10', '233.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Белгородская область', '12000.00', '2400.00', '408.00', '192.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Брянская область', '6552.00', '1310.40', '222.80', '104.80');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Владимирская область', '9864.00', '1972.80', '335.40', '157.80');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Волгоградская область', '14562.00', '2912.40', '495.10', '233.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Вологодская область', '4536.00', '907.20', '154.20', '72.60');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Воронежская область', '12474.00', '2494.80', '424.10', '199.60');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Ивановская область', '4914.00', '982.80', '167.10', '78.60');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Иркутская область', '4110.00', '822.00', '139.70', '65.80');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Калининградская область', '13600.00', '2720.00', '462.40', '217.60');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Калужская область', '6552.00', '1310.40', '222.80', '104.80');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Кемеровская область', '7398.00', '1479.60', '251.50', '118.40');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Кировская область', '4824.00', '964.80', '164.00', '77.20');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Костромская область', '4824.00', '964.80', '164.00', '77.20');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Курганская область', '5742.00', '1148.40', '195.20', '91.90');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Курская область', '12000.00', '2400.00', '408.00', '192.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Ленинградская область и г. Санкт-Петербург', '15812.00', '3162.40', '537.60', '253.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Липецкая область', '12000.00', '2400.00', '408.00', '192.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Магаданская область', '5298.00', '1059.60', '180.10', '84.80');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Московская область и г. Москва', '18500.00', '3700.00', '629.00', '296.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Мурманская область', '11034.00', '2206.80', '375.20', '176.50');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Нижегородская область', '11124.00', '2224.80', '378.20', '178.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Новгородская область', '6174.00', '1234.80', '209.90', '98.80');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Новосибирская область', '5310.00', '1062.00', '180.50', '85.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Омская область', '4770.00', '954.00', '162.20', '76.30');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Оренбургская область', '12100.00', '2420.00', '411.40', '193.60');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Орловская область', '6570.00', '1314.00', '223.40', '105.10');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Пензенская область', '12582.00', '2516.40', '427.80', '201.30');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Псковская область', '12294.00', '2458.80', '418.00', '196.70');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Ростовская область', '14562.00', '2912.40', '495.10', '233.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Рязанская область', '9864.00', '1972.80', '335.40', '157.80');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Самарская область', '12582.00', '2516.40', '427.80', '201.30');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Саратовская область', '12582.00', '2516.40', '427.80', '201.30');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Сахалинская область', '7686.00', '1537.20', '261.30', '123.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Свердловская область', '6238.00', '1247.60', '212.10', '99.80');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Смоленская область', '6552.00', '1310.40', '222.80', '104.80');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Тамбовская область', '12000.00', '2400.00', '408.00', '192.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Тверская область', '6174.00', '1234.80', '209.90', '98.80');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Томская область', '4558.00', '911.60', '155.00', '72.90');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Тульская область', '6570.00', '1314.00', '223.40', '105.10');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Тюменская область', '4320.00', '864.00', '146.90', '69.10');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Ульяновская область', '12582.00', '2516.40', '427.80', '201.30');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Челябинская область', '5742.00', '1148.40', '195.20', '91.90');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Ярославская область', '4914.00', '982.80', '167.10', '78.60');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Еврейская автономная область', '7038.00', '1407.60', '239.30', '112.60');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Ненецкий автономный округ', '5190.00', '1038.00', '176.50', '83.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Ханты-Мансийский автономный округ - Югра', '7440.00', '1488.00', '253.00', '119.00');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Чукотский автономный округ', '5298.00', '1059.60', '180.10', '84.80');
INSERT INTO TaxPricesExtra (SubjectRF, TreeCessationOfGrowth, TreeWithoutCessationOfGrowth, BushCessationOfGrowth, BushWithoutCessationOfGrowth) VALUES ('Ямало-Ненецкий автономный округ', '5190.00', '1038.00', '176.50', '83.00');
