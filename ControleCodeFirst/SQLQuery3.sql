Use BDPol;
INSERT INTO Chercheurs (Nom, Prenom, Email) 
VALUES ('El Mernissi', 'Fatima Zahra', 'fz.elmernissi@example.com'),
       ('Bouhaddioui', 'Youssef', 'youssef.bouhaddioui@example.com'),
       ('Saidi', 'Sanaa', 'sanaa.saidi@example.com');
INSERT INTO Lieux (ville, adresse) 
VALUES ('Casablanca', 'Rue Mohammed V'),
       ('Marrakech', 'Avenue Hassan II'),
       ('Fès', 'Place ','Rcif');
INSERT INTO PollutionDatas (Date, NivPollution) 
VALUES ('2024-03-24', 'Niveau1'),
       ('2024-03-25', 'Niveau2'),
       ('2024-03-26', 'Niveau3');

INSERT INTO PollutionEvenements (ID, nom, cause, LieuId, DataId) 
VALUES (1, 'Déversement industriel', 'Défaillance des équipements', 1, 1),
       (2, 'Brûlage des déchets', 'Pratique courante', 2, 2),
       (3, 'Émission de gaz toxiques', 'Accident chimique', 3, 3);