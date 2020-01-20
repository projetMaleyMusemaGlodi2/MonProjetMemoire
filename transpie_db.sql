-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le :  lun. 20 jan. 2020 à 20:09
-- Version du serveur :  10.3.16-MariaDB
-- Version de PHP :  7.2.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `transpie_db`
--

-- --------------------------------------------------------

--
-- Structure de la table `taffectationchauffeur`
--

CREATE TABLE `taffectationchauffeur` (
  `id` int(11) NOT NULL,
  `refEngin` int(11) NOT NULL,
  `refChauffeur` int(11) NOT NULL,
  `dateAffectation` datetime NOT NULL DEFAULT current_timestamp(),
  `usersession` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `taffectationchauffeur`
--

INSERT INTO `taffectationchauffeur` (`id`, `refEngin`, `refChauffeur`, `dateAffectation`, `usersession`) VALUES
(1, 1, 1, '2020-01-01 04:36:10', 'admin'),
(2, 2, 2, '2020-01-01 04:38:10', 'admin'),
(3, 3, 3, '2020-01-01 04:39:50', 'ok'),
(4, 5, 4, '2020-01-13 21:47:39', 'jeanpie');

--
-- Déclencheurs `taffectationchauffeur`
--
DELIMITER $$
CREATE TRIGGER `inertHistoriqueAffectChauff` AFTER UPDATE ON `taffectationchauffeur` FOR EACH ROW INSERT INTO thistoriqueaffectchauffeur values (OLD.id,OLD.dateaffectation,OLD.refChauffeur,OLD.refEngin,OLD.usersession,current_timestamp())
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `insertdeletedAffectation` AFTER DELETE ON `taffectationchauffeur` FOR EACH ROW INSERT INTO thistoriqueaffectchauffeur values (OLD.id,OLD.dateaffectation,OLD.refChauffeur,OLD.refEngin,OLD.usersession,current_timestamp())
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `tagent`
--

CREATE TABLE `tagent` (
  `id` int(11) NOT NULL,
  `noms` varchar(100) NOT NULL,
  `adresse` varchar(100) NOT NULL,
  `contact` varchar(100) NOT NULL,
  `mail` varchar(100) NOT NULL,
  `sexe` varchar(10) NOT NULL,
  `datenaissance` date NOT NULL,
  `lieunaissance` varchar(100) NOT NULL,
  `etatcivil` varchar(100) NOT NULL,
  `niveauetude` varchar(100) NOT NULL,
  `fonction` varchar(100) NOT NULL,
  `image` varchar(500) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `usersession` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tagent`
--

INSERT INTO `tagent` (`id`, `noms`, `adresse`, `contact`, `mail`, `sexe`, `datenaissance`, `lieunaissance`, `etatcivil`, `niveauetude`, `fonction`, `image`, `username`, `password`, `usersession`) VALUES
(1, 'GLODI', 'Himbi', '0993402772', 'glodimaley@mail.com', 'M', '2019-12-01', 'GOMA', 'CELIBATAIRE', 'LICENCE', 'AGENT', '', 'glodi', '21232f297a57a5a743894a0e4a801fc3', 'admin');

-- --------------------------------------------------------

--
-- Structure de la table `taide`
--

CREATE TABLE `taide` (
  `id` int(11) NOT NULL,
  `message` varchar(500) NOT NULL,
  `usersession` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `taide`
--

INSERT INTO `taide` (`id`, `message`, `usersession`) VALUES
(1, 'Pour l\'utilisation du systeme il faut d\'abord l\'ouvrir etc.', 'admin');

-- --------------------------------------------------------

--
-- Structure de la table `talerte`
--

CREATE TABLE `talerte` (
  `id` int(11) NOT NULL,
  `message` varchar(500) NOT NULL,
  `usersession` varchar(100) NOT NULL,
  `dateaction` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `talerte`
--

INSERT INTO `talerte` (`id`, `message`, `usersession`, `dateaction`) VALUES
(2, 'Il a un changement de prix de transport qui va s\'appliquer d\'ici fevrier 2020 pour raison de la caisse social. merci', 'admin', '2020-01-19 04:15:57');

-- --------------------------------------------------------

--
-- Structure de la table `tcategorieengin`
--

CREATE TABLE `tcategorieengin` (
  `id` int(11) NOT NULL,
  `designation` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tcategorieengin`
--

INSERT INTO `tcategorieengin` (`id`, `designation`) VALUES
(1, 'GRAND BUS'),
(2, 'MINI-BUS');

-- --------------------------------------------------------

--
-- Structure de la table `tchargecompteclient`
--

CREATE TABLE `tchargecompteclient` (
  `id` int(11) NOT NULL,
  `refClient` int(11) NOT NULL,
  `montant` double NOT NULL,
  `datecharge` datetime NOT NULL DEFAULT current_timestamp(),
  `usersession` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tchargecompteclient`
--

INSERT INTO `tchargecompteclient` (`id`, `refClient`, `montant`, `datecharge`, `usersession`) VALUES
(5, 1, 2000, '2020-01-06 17:14:41', 'admin'),
(6, 1, 300, '2020-01-06 17:18:56', 'glodi'),
(7, 1, 1000, '2020-01-06 17:20:21', 'glodi'),
(8, 1, 2000, '2020-01-19 20:31:11', 'glodi');

--
-- Déclencheurs `tchargecompteclient`
--
DELIMITER $$
CREATE TRIGGER `rechargeCompteClient` AFTER INSERT ON `tchargecompteclient` FOR EACH ROW UPDATE tclient set compte=compte+NEW.montant where tclient.id=new.refClient
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `tchauffeur`
--

CREATE TABLE `tchauffeur` (
  `id` int(11) NOT NULL,
  `noms` varchar(100) NOT NULL,
  `adresse` varchar(100) NOT NULL,
  `contact` varchar(100) NOT NULL,
  `mail` varchar(100) NOT NULL,
  `typepieceid` varchar(100) NOT NULL,
  `numeropieceid` varchar(100) NOT NULL,
  `image` varchar(500) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `usersession` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tchauffeur`
--

INSERT INTO `tchauffeur` (`id`, `noms`, `adresse`, `contact`, `mail`, `typepieceid`, `numeropieceid`, `image`, `username`, `password`, `usersession`) VALUES
(1, 'ACHILE', 'Katoyi', '0993402772', 'kaseso@gmail.com', 'Carte d\'electeur', '67009876', 'image_845849.jpg', 'achile', '21232f297a57a5a743894a0e4a801fc3', 'achile'),
(2, 'ARSENE', 'ULPGL', '0993402772', 'arsene@gmail.com', 'Carte electeur', '45678', '', 'arsene', '21232f297a57a5a743894a0e4a801fc3', 'admin'),
(3, 'JACQUES', 'HIMBI', '0993402772', 'jacques@gmail.com', 'Carte', '56789', '', 'jacques', '21232f297a57a5a743894a0e4a801fc3', 'admin'),
(4, 'JUSLIN', 'Himbi', '0992992063', 'juslin@gmail.com', 'carte', '45673', 'image_540191.jpg', 'juslin', '21232f297a57a5a743894a0e4a801fc3', 'juslin');

-- --------------------------------------------------------

--
-- Structure de la table `tclient`
--

CREATE TABLE `tclient` (
  `id` int(11) NOT NULL,
  `noms` varchar(100) NOT NULL,
  `adresse` varchar(100) NOT NULL,
  `contact` varchar(100) NOT NULL,
  `mail` varchar(100) NOT NULL,
  `typepieceid` varchar(100) NOT NULL,
  `numeropieceid` varchar(100) NOT NULL,
  `image` varchar(500) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `usersession` varchar(100) NOT NULL,
  `compte` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tclient`
--

INSERT INTO `tclient` (`id`, `noms`, `adresse`, `contact`, `mail`, `typepieceid`, `numeropieceid`, `image`, `username`, `password`, `usersession`, `compte`) VALUES
(1, 'CLAUDE KUBUYA', 'Carmel', '0992992063', 'glodimaley@gmail.com', 'carte d\'electeur', '567890', 'image_31286.jpg', 'claude', '21232f297a57a5a743894a0e4a801fc3', 'claude', 1900),
(2, 'YASSIN', 'TMK', '0993402772', 'yassi@gmail.com', '5669', '41236', 'image_44815.jpg', 'admin', '21232f297a57a5a743894a0e4a801fc3', 'admin', 2700);

--
-- Déclencheurs `tclient`
--
DELIMITER $$
CREATE TRIGGER `createCompteClient` AFTER INSERT ON `tclient` FOR EACH ROW UPDATE tclient set compte=0 where tclient.id=new.id
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `tdescriptionese`
--

CREATE TABLE `tdescriptionese` (
  `id` int(11) NOT NULL,
  `message` varchar(500) NOT NULL,
  `usersession` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tdescriptionese`
--

INSERT INTO `tdescriptionese` (`id`, `message`, `usersession`) VALUES
(1, 'L\'entreprise TAP&LEAVE est une entreprise de gestion de transport public.', 'admin');

-- --------------------------------------------------------

--
-- Structure de la table `tengin`
--

CREATE TABLE `tengin` (
  `id` int(11) NOT NULL,
  `marque` varchar(100) NOT NULL,
  `couleur` varchar(100) NOT NULL,
  `numeroplaque` varchar(100) NOT NULL,
  `refProprietaire` int(11) NOT NULL,
  `refCategorie` int(11) NOT NULL,
  `nombreplace` int(11) NOT NULL,
  `compte` double DEFAULT NULL,
  `usersession` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tengin`
--

INSERT INTO `tengin` (`id`, `marque`, `couleur`, `numeroplaque`, `refProprietaire`, `refCategorie`, `nombreplace`, `compte`, `usersession`) VALUES
(1, 'BUS1', 'Blanche', '34567-RDGO78', 1, 1, 18, 2300, 'admin'),
(2, 'BUS2', 'Blanche', '56GO6789', 1, 2, 19, 1000, 'admin'),
(3, 'BUS3', 'Rouge', '34567GO87', 2, 1, 20, 2800, 'admin'),
(4, 'Toyota', 'Blanche', '578GO', 2, 1, 20, 0, 'jaenpie'),
(5, 'Benz22', 'Jaune', 'GO5609', 2, 1, 20, 0, 'jeanpie'),
(6, 'ToyotaBenz', 'blanche', '358GG', 2, 1, 20, 0, 'jeanpie');

--
-- Déclencheurs `tengin`
--
DELIMITER $$
CREATE TRIGGER `createCompteBus` AFTER INSERT ON `tengin` FOR EACH ROW update tengin set compte=0 where tengin.id=new.id
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `thistoriqueaffectchauffeur`
--

CREATE TABLE `thistoriqueaffectchauffeur` (
  `id` int(11) NOT NULL,
  `dateaffectation` date NOT NULL,
  `refChauffeur` int(11) NOT NULL,
  `refEngin` int(11) NOT NULL,
  `usersession` varchar(100) NOT NULL,
  `dateAction` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `thistoriqueaffectchauffeur`
--

INSERT INTO `thistoriqueaffectchauffeur` (`id`, `dateaffectation`, `refChauffeur`, `refEngin`, `usersession`, `dateAction`) VALUES
(5, '2020-01-19', 2, 6, 'admin', '2020-01-19 04:03:34');

-- --------------------------------------------------------

--
-- Structure de la table `tpaiement`
--

CREATE TABLE `tpaiement` (
  `id` int(11) NOT NULL,
  `montant` double NOT NULL,
  `refClient` int(11) NOT NULL,
  `refAffectChauffeur` int(11) NOT NULL,
  `datepaiement` datetime NOT NULL DEFAULT current_timestamp(),
  `usersession` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tpaiement`
--

INSERT INTO `tpaiement` (`id`, `montant`, `refClient`, `refAffectChauffeur`, `datepaiement`, `usersession`) VALUES
(1786, 300, 1, 1, '2020-01-06 17:18:17', 'admin'),
(1787, 300, 1, 1, '2020-01-06 17:20:48', 'glodi'),
(1790, 300, 2, 3, '2020-01-19 11:30:27', 'glodi'),
(1791, 300, 2, 3, '2020-01-19 11:30:28', 'glodi'),
(1792, 300, 2, 3, '2020-01-19 11:30:28', 'glodi'),
(1824, 300, 2, 3, '2020-01-19 17:07:33', 'glodi'),
(1825, 300, 2, 3, '2020-01-19 17:07:33', 'glodi'),
(1826, 300, 1, 3, '2020-01-19 20:31:32', 'glodi'),
(1827, 300, 2, 1, '2020-01-20 10:51:59', 'glodi');

--
-- Déclencheurs `tpaiement`
--
DELIMITER $$
CREATE TRIGGER `dechargeCompteClient` AFTER INSERT ON `tpaiement` FOR EACH ROW BEGIN
DECLARE idBus integer DEFAULT 0;
SET idBus= (SELECT refEngin from taffectationchauffeur
WHERE taffectationchauffeur.id=New.refAffectChauffeur);



UPDATE tclient set compte=compte-New.montant where tclient.id=new.refClient;
UPDATE tengin set compte=compte+New.montant where tEngin.id=idBus;

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `tparametreprix`
--

CREATE TABLE `tparametreprix` (
  `id` int(11) NOT NULL,
  `prix` double NOT NULL,
  `usersession` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tparametreprix`
--

INSERT INTO `tparametreprix` (`id`, `prix`, `usersession`) VALUES
(1, 300, 'admin');

-- --------------------------------------------------------

--
-- Structure de la table `tproprietaire`
--

CREATE TABLE `tproprietaire` (
  `id` int(11) NOT NULL,
  `noms` varchar(100) NOT NULL,
  `adresse` varchar(100) NOT NULL,
  `contact` varchar(100) NOT NULL,
  `mail` varchar(100) NOT NULL,
  `typepieceid` varchar(100) NOT NULL,
  `numeropieceid` varchar(100) NOT NULL,
  `image` varchar(500) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `usersession` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tproprietaire`
--

INSERT INTO `tproprietaire` (`id`, `noms`, `adresse`, `contact`, `mail`, `typepieceid`, `numeropieceid`, `image`, `username`, `password`, `usersession`) VALUES
(1, 'ARNOLD', 'Ndosho', '0992992063', 'kakule@gmail.com', 'carte d\'electeur', '5678', 'image_752857.jpg', 'kakule', '21232f297a57a5a743894a0e4a801fc3', 'kakule'),
(2, 'JEANPIERE', 'Le volcan', '0993402772', 'jeanpiere@gmail.com', 'Carte d\'Electeur', '3456', 'image_80613.jpg', 'jeanpie', '21232f297a57a5a743894a0e4a801fc3', 'jeanpie'),
(3, 'ROBERT', 'Bk', '0993402772', 'robert@gmail.com', 'carte electeur', '765543', '', 'robert', '21232f297a57a5a743894a0e4a801fc3', 'robert');

-- --------------------------------------------------------

--
-- Structure de la table `tretraitbus`
--

CREATE TABLE `tretraitbus` (
  `id` int(11) NOT NULL,
  `refAffectChauffeur` int(11) NOT NULL,
  `montant` double NOT NULL,
  `dateretrait` date NOT NULL DEFAULT current_timestamp(),
  `libelle` varchar(100) NOT NULL,
  `usersession` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tretraitbus`
--

INSERT INTO `tretraitbus` (`id`, `refAffectChauffeur`, `montant`, `dateretrait`, `libelle`, `usersession`) VALUES
(2, 2, 200, '2020-01-14', 'ok', 'glodi'),
(3, 3, 200, '2020-01-19', 'ok', 'glodi');

--
-- Déclencheurs `tretraitbus`
--
DELIMITER $$
CREATE TRIGGER `retraitCompteBus` AFTER INSERT ON `tretraitbus` FOR EACH ROW BEGIN
DECLARE idBus integer DEFAULT 0;
SET idBus= (SELECT refEngin from taffectationchauffeur
WHERE taffectationchauffeur.id=New.refAffectChauffeur);

UPDATE tengin set compte=compte-New.montant where tengin.id=idBus;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `tuser`
--

CREATE TABLE `tuser` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `niveau` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `tvirement`
--

CREATE TABLE `tvirement` (
  `id` int(11) NOT NULL,
  `montant` double NOT NULL,
  `refAffectChauffeur` int(11) NOT NULL,
  `refEngin` int(11) NOT NULL,
  `libelle` varchar(100) NOT NULL,
  `datevirement` datetime NOT NULL DEFAULT current_timestamp(),
  `usersession` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tvirement`
--

INSERT INTO `tvirement` (`id`, `montant`, `refAffectChauffeur`, `refEngin`, `libelle`, `datevirement`, `usersession`) VALUES
(1, 800, 2, 1, 'ok', '2020-01-14 18:12:03', 'glodi');

--
-- Déclencheurs `tvirement`
--
DELIMITER $$
CREATE TRIGGER `virementCompte` BEFORE INSERT ON `tvirement` FOR EACH ROW BEGIN
DECLARE idBus integer DEFAULT 0;
SET idBus= (SELECT refEngin from taffectationchauffeur
WHERE taffectationchauffeur.id=New.refAffectChauffeur);

UPDATE tengin set compte=compte+New.montant where tengin.id=idBus;

UPDATE tengin set compte=compte-New.montant where tengin.id=New.refEngin;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `vaffectationchauffeur`
-- (Voir ci-dessous la vue réelle)
--
CREATE TABLE `vaffectationchauffeur` (
`id` int(11)
,`refEngin` int(11)
,`refChauffeur` int(11)
,`dateAffectation` datetime
,`usersession` varchar(100)
,`NomsBus` varchar(100)
,`couleur` varchar(100)
,`numeroplaque` varchar(100)
,`refProprietaire` int(11)
,`refCategorie` int(11)
,`nombreplace` int(11)
,`CompteBus` double
,`Proprietaire` varchar(100)
,`CategorieEngin` varchar(100)
,`Chauffeur` varchar(100)
,`compte` double
,`detailEngin` varchar(459)
);

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `vengin`
-- (Voir ci-dessous la vue réelle)
--
CREATE TABLE `vengin` (
`id` int(11)
,`marque` varchar(100)
,`couleur` varchar(100)
,`numeroplaque` varchar(100)
,`refProprietaire` int(11)
,`refCategorie` int(11)
,`nombreplace` int(11)
,`compte` double
,`usersession` varchar(100)
,`noms` varchar(100)
,`Categorie` varchar(100)
,`detailEngin` varchar(508)
);

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `vhistoriqueaffectchauffeur`
-- (Voir ci-dessous la vue réelle)
--
CREATE TABLE `vhistoriqueaffectchauffeur` (
`id` int(11)
,`refEngin` int(11)
,`refChauffeur` int(11)
,`dateAffectation` date
,`usersession` varchar(100)
,`NomsBus` varchar(100)
,`couleur` varchar(100)
,`numeroplaque` varchar(100)
,`refProprietaire` int(11)
,`refCategorie` int(11)
,`nombreplace` int(11)
,`compte` double
,`Proprietaire` varchar(100)
,`CategorieEngin` varchar(100)
,`Chauffeur` varchar(100)
);

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `vpaiementtransport`
-- (Voir ci-dessous la vue réelle)
--
CREATE TABLE `vpaiementtransport` (
`id` int(11)
,`montant` double
,`refClient` int(11)
,`refAffectChauffeur` int(11)
,`datepaiement` datetime
,`usersession` varchar(100)
,`Client` varchar(100)
,`contactClient` varchar(100)
,`detailEngin` varchar(459)
,`refEngin` int(11)
,`refChauffeur` int(11)
,`refProprietaire` int(11)
,`refCategorie` int(11)
);

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `vparametreprix`
-- (Voir ci-dessous la vue réelle)
--
CREATE TABLE `vparametreprix` (
`id` int(11)
,`Prix` varchar(39)
);

-- --------------------------------------------------------

--
-- Structure de la vue `vaffectationchauffeur`
--
DROP TABLE IF EXISTS `vaffectationchauffeur`;

CREATE ALGORITHM=UNDEFINED DEFINER=`` SQL SECURITY DEFINER VIEW `vaffectationchauffeur`  AS  select `taffectationchauffeur`.`id` AS `id`,`taffectationchauffeur`.`refEngin` AS `refEngin`,`taffectationchauffeur`.`refChauffeur` AS `refChauffeur`,`taffectationchauffeur`.`dateAffectation` AS `dateAffectation`,`taffectationchauffeur`.`usersession` AS `usersession`,`tengin`.`marque` AS `NomsBus`,`tengin`.`couleur` AS `couleur`,`tengin`.`numeroplaque` AS `numeroplaque`,`tengin`.`refProprietaire` AS `refProprietaire`,`tengin`.`refCategorie` AS `refCategorie`,`tengin`.`nombreplace` AS `nombreplace`,`tengin`.`compte` AS `CompteBus`,`tproprietaire`.`noms` AS `Proprietaire`,`tcategorieengin`.`designation` AS `CategorieEngin`,`tchauffeur`.`noms` AS `Chauffeur`,`tengin`.`compte` AS `compte`,concat('Prop.:',`tproprietaire`.`noms`,' ; Chauf.:',`tchauffeur`.`noms`,' ; Engin:',`tengin`.`marque`,'=>','(' + `tengin`.`numeroplaque` + ')',' ;  Cat.:',`tcategorieengin`.`designation`) AS `detailEngin` from ((((`taffectationchauffeur` join `tengin` on(`tengin`.`id` = `taffectationchauffeur`.`refEngin`)) join `tproprietaire` on(`tproprietaire`.`id` = `tengin`.`refProprietaire`)) join `tcategorieengin` on(`tcategorieengin`.`id` = `tengin`.`refCategorie`)) join `tchauffeur` on(`tchauffeur`.`id` = `taffectationchauffeur`.`refChauffeur`)) ;

-- --------------------------------------------------------

--
-- Structure de la vue `vengin`
--
DROP TABLE IF EXISTS `vengin`;

CREATE ALGORITHM=UNDEFINED DEFINER=`` SQL SECURITY DEFINER VIEW `vengin`  AS  select `tengin`.`id` AS `id`,`tengin`.`marque` AS `marque`,`tengin`.`couleur` AS `couleur`,`tengin`.`numeroplaque` AS `numeroplaque`,`tengin`.`refProprietaire` AS `refProprietaire`,`tengin`.`refCategorie` AS `refCategorie`,`tengin`.`nombreplace` AS `nombreplace`,`tengin`.`compte` AS `compte`,`tengin`.`usersession` AS `usersession`,`tproprietaire`.`noms` AS `noms`,`tcategorieengin`.`designation` AS `Categorie`,concat(`tcategorieengin`.`designation`,'=>',`tengin`.`marque`,'=>',`tengin`.`numeroplaque`,'=>',`tengin`.`couleur`,'=>',`tproprietaire`.`noms`) AS `detailEngin` from ((`tengin` join `tcategorieengin` on(`tcategorieengin`.`id` = `tengin`.`refCategorie`)) join `tproprietaire` on(`tproprietaire`.`id` = `tengin`.`refProprietaire`)) ;

-- --------------------------------------------------------

--
-- Structure de la vue `vhistoriqueaffectchauffeur`
--
DROP TABLE IF EXISTS `vhistoriqueaffectchauffeur`;

CREATE ALGORITHM=UNDEFINED DEFINER=`` SQL SECURITY DEFINER VIEW `vhistoriqueaffectchauffeur`  AS  select `thistoriqueaffectchauffeur`.`id` AS `id`,`thistoriqueaffectchauffeur`.`refEngin` AS `refEngin`,`thistoriqueaffectchauffeur`.`refChauffeur` AS `refChauffeur`,`thistoriqueaffectchauffeur`.`dateaffectation` AS `dateAffectation`,`thistoriqueaffectchauffeur`.`usersession` AS `usersession`,`tengin`.`marque` AS `NomsBus`,`tengin`.`couleur` AS `couleur`,`tengin`.`numeroplaque` AS `numeroplaque`,`tengin`.`refProprietaire` AS `refProprietaire`,`tengin`.`refCategorie` AS `refCategorie`,`tengin`.`nombreplace` AS `nombreplace`,`tengin`.`compte` AS `compte`,`tproprietaire`.`noms` AS `Proprietaire`,`tcategorieengin`.`designation` AS `CategorieEngin`,`tchauffeur`.`noms` AS `Chauffeur` from ((((`thistoriqueaffectchauffeur` join `tengin` on(`tengin`.`id` = `thistoriqueaffectchauffeur`.`refEngin`)) join `tproprietaire` on(`tproprietaire`.`id` = `tengin`.`refProprietaire`)) join `tcategorieengin` on(`tcategorieengin`.`id` = `tengin`.`refCategorie`)) join `tchauffeur` on(`tchauffeur`.`id` = `thistoriqueaffectchauffeur`.`refChauffeur`)) ;

-- --------------------------------------------------------

--
-- Structure de la vue `vpaiementtransport`
--
DROP TABLE IF EXISTS `vpaiementtransport`;

CREATE ALGORITHM=UNDEFINED DEFINER=`` SQL SECURITY DEFINER VIEW `vpaiementtransport`  AS  select `tpaiement`.`id` AS `id`,`tpaiement`.`montant` AS `montant`,`tpaiement`.`refClient` AS `refClient`,`tpaiement`.`refAffectChauffeur` AS `refAffectChauffeur`,`tpaiement`.`datepaiement` AS `datepaiement`,`tpaiement`.`usersession` AS `usersession`,`tclient`.`noms` AS `Client`,`tclient`.`contact` AS `contactClient`,`vaffectationchauffeur`.`detailEngin` AS `detailEngin`,`vaffectationchauffeur`.`refEngin` AS `refEngin`,`vaffectationchauffeur`.`refChauffeur` AS `refChauffeur`,`vaffectationchauffeur`.`refProprietaire` AS `refProprietaire`,`vaffectationchauffeur`.`refCategorie` AS `refCategorie` from ((`tpaiement` join `tclient` on(`tclient`.`id` = `tpaiement`.`refClient`)) join `vaffectationchauffeur` on(`vaffectationchauffeur`.`id` = `tpaiement`.`refAffectChauffeur`)) ;

-- --------------------------------------------------------

--
-- Structure de la vue `vparametreprix`
--
DROP TABLE IF EXISTS `vparametreprix`;

CREATE ALGORITHM=UNDEFINED DEFINER=`` SQL SECURITY DEFINER VIEW `vparametreprix`  AS  select `tparametreprix`.`id` AS `id`,concat('Prix Actuel :',`tparametreprix`.`prix` + '',' FC') AS `Prix` from `tparametreprix` ;

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `taffectationchauffeur`
--
ALTER TABLE `taffectationchauffeur`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `uniqueAffectation` (`refEngin`,`refChauffeur`),
  ADD UNIQUE KEY `uniqueEngin` (`refEngin`),
  ADD KEY `refEngin` (`refEngin`),
  ADD KEY `refChauffeur` (`refChauffeur`);

--
-- Index pour la table `tagent`
--
ALTER TABLE `tagent`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `taide`
--
ALTER TABLE `taide`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `talerte`
--
ALTER TABLE `talerte`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `tcategorieengin`
--
ALTER TABLE `tcategorieengin`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `tchargecompteclient`
--
ALTER TABLE `tchargecompteclient`
  ADD PRIMARY KEY (`id`),
  ADD KEY `refClient` (`refClient`);

--
-- Index pour la table `tchauffeur`
--
ALTER TABLE `tchauffeur`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `uniqueUser` (`username`,`password`);

--
-- Index pour la table `tclient`
--
ALTER TABLE `tclient`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `uniqueUser` (`username`,`password`);

--
-- Index pour la table `tdescriptionese`
--
ALTER TABLE `tdescriptionese`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `tengin`
--
ALTER TABLE `tengin`
  ADD PRIMARY KEY (`id`),
  ADD KEY `refProprietaire` (`refProprietaire`),
  ADD KEY `refCategorie` (`refCategorie`);

--
-- Index pour la table `thistoriqueaffectchauffeur`
--
ALTER TABLE `thistoriqueaffectchauffeur`
  ADD KEY `refChauffeur` (`refChauffeur`),
  ADD KEY `refEngin` (`refEngin`);

--
-- Index pour la table `tpaiement`
--
ALTER TABLE `tpaiement`
  ADD PRIMARY KEY (`id`),
  ADD KEY `refClient` (`refClient`),
  ADD KEY `refAffectChauffeur` (`refAffectChauffeur`);

--
-- Index pour la table `tparametreprix`
--
ALTER TABLE `tparametreprix`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `tproprietaire`
--
ALTER TABLE `tproprietaire`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `uniqueUserProp` (`username`,`password`);

--
-- Index pour la table `tretraitbus`
--
ALTER TABLE `tretraitbus`
  ADD PRIMARY KEY (`id`),
  ADD KEY `refAffectChauffeur` (`refAffectChauffeur`);

--
-- Index pour la table `tuser`
--
ALTER TABLE `tuser`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `tvirement`
--
ALTER TABLE `tvirement`
  ADD PRIMARY KEY (`id`),
  ADD KEY `refAffectChauffeur` (`refAffectChauffeur`),
  ADD KEY `refEngin` (`refEngin`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `taffectationchauffeur`
--
ALTER TABLE `taffectationchauffeur`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT pour la table `taide`
--
ALTER TABLE `taide`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `talerte`
--
ALTER TABLE `talerte`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pour la table `tcategorieengin`
--
ALTER TABLE `tcategorieengin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pour la table `tchargecompteclient`
--
ALTER TABLE `tchargecompteclient`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT pour la table `tchauffeur`
--
ALTER TABLE `tchauffeur`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pour la table `tdescriptionese`
--
ALTER TABLE `tdescriptionese`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `tengin`
--
ALTER TABLE `tengin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT pour la table `tpaiement`
--
ALTER TABLE `tpaiement`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1828;

--
-- AUTO_INCREMENT pour la table `tparametreprix`
--
ALTER TABLE `tparametreprix`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `tproprietaire`
--
ALTER TABLE `tproprietaire`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `tretraitbus`
--
ALTER TABLE `tretraitbus`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `tuser`
--
ALTER TABLE `tuser`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `tvirement`
--
ALTER TABLE `tvirement`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `taffectationchauffeur`
--
ALTER TABLE `taffectationchauffeur`
  ADD CONSTRAINT `taffectationchauffeur_ibfk_1` FOREIGN KEY (`refEngin`) REFERENCES `tengin` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `taffectationchauffeur_ibfk_2` FOREIGN KEY (`refChauffeur`) REFERENCES `tchauffeur` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `tengin`
--
ALTER TABLE `tengin`
  ADD CONSTRAINT `tengin_ibfk_1` FOREIGN KEY (`refProprietaire`) REFERENCES `tproprietaire` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `tengin_ibfk_2` FOREIGN KEY (`refCategorie`) REFERENCES `tcategorieengin` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `thistoriqueaffectchauffeur`
--
ALTER TABLE `thistoriqueaffectchauffeur`
  ADD CONSTRAINT `thistoriqueaffectchauffeur_ibfk_1` FOREIGN KEY (`refEngin`) REFERENCES `tengin` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `thistoriqueaffectchauffeur_ibfk_2` FOREIGN KEY (`refChauffeur`) REFERENCES `tchauffeur` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `tpaiement`
--
ALTER TABLE `tpaiement`
  ADD CONSTRAINT `tpaiement_ibfk_1` FOREIGN KEY (`refAffectChauffeur`) REFERENCES `taffectationchauffeur` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `tpaiement_ibfk_2` FOREIGN KEY (`refClient`) REFERENCES `tclient` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `tretraitbus`
--
ALTER TABLE `tretraitbus`
  ADD CONSTRAINT `tretraitbus_ibfk_1` FOREIGN KEY (`refAffectChauffeur`) REFERENCES `taffectationchauffeur` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `tvirement`
--
ALTER TABLE `tvirement`
  ADD CONSTRAINT `tvirement_ibfk_1` FOREIGN KEY (`refAffectChauffeur`) REFERENCES `taffectationchauffeur` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `tvirement_ibfk_2` FOREIGN KEY (`refEngin`) REFERENCES `tengin` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
