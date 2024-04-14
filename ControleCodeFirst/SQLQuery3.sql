Use BDPol;
INSERT INTO Chercheurs (Nom, Prenom, Email) 
VALUES ('El Mernissi', 'Fatima Zahra', 'fz.elmernissi@example.com'),
       ('Bouhaddioui', 'Youssef', 'youssef.bouhaddioui@example.com'),
       ('Saidi', 'Sanaa', 'sanaa.saidi@example.com');
INSERT INTO Lieux (ville, adresse) 
VALUES ('Casablanca', 'Rue Mohammed V'),
       ('Marrakech', 'Avenue Hassan II'),
       ('F�s', 'Place ','Rcif');
INSERT INTO PollutionDatas (Date, NivPollution) 
VALUES ('2024-03-24', 'Niveau1'),
       ('2024-03-25', 'Niveau2'),
       ('2024-03-26', 'Niveau3');

INSERT INTO PollutionEvenements (ID, nom, cause, LieuId, DataId) 
VALUES (1, 'D�versement industriel', 'D�faillance des �quipements', 1, 1),
       (2, 'Br�lage des d�chets', 'Pratique courante', 2, 2),
       (3, '�mission de gaz toxiques', 'Accident chimique', 3, 3);