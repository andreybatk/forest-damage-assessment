DROP TABLE IF EXISTS BreedDiameterModels;
CREATE TABLE BreedDiameterModels (
  ID INT IDENTITY (1, 1) NOT NULL,
  Breed nvarchar(40) DEFAULT NULL,
  C1 nvarchar(10) DEFAULT NULL,
  C2 nvarchar(10) DEFAULT NULL,
  C3 nvarchar(10) DEFAULT NULL,
  C4 nvarchar(10) DEFAULT NULL,
)
INSERT INTO BreedDiameterModels (Breed, C1, C2, C3, C4) VALUES
('Ель', '92,166', '-4,025', '-99,75', '-0,0077'),
('Береза', '80,735', '-3,897', '-99,65', '-0,0057'),
('Липа', '80,207', '-4,373', '-99,63', '0,0033'),
('Пихта', '70,912', '-4,251', '-100,00', '-0,0106'),
('Ольха серая', '64,191', '-4,178', '-100,25', '-0,0209'),
('Осина', '68,248', '-4,621', '-99,95', '-0,0023'),
('Сосна', '36,594', '-2,756', '-99,45', '-0,0171');