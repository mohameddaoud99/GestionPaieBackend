-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : localhost:3306
-- Généré le : ven. 07 avr. 2023 à 14:45
-- Version du serveur : 5.7.24
-- Version de PHP : 8.1.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `userpaie`
--

-- --------------------------------------------------------

--
-- Structure de la table `acceemodule__`
--

CREATE TABLE `acceemodule__` (
  `module` varchar(50) NOT NULL,
  `accee` varchar(1) DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `couleur`
--

CREATE TABLE `couleur` (
  `couleur1` int(11) NOT NULL DEFAULT '0',
  `couleur2` int(11) DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `couleur`
--

INSERT INTO `couleur` (`couleur1`, `couleur2`) VALUES
(16777215, 128);

-- --------------------------------------------------------

--
-- Structure de la table `importation`
--

CREATE TABLE `importation` (
  `menu` varchar(30) NOT NULL,
  `sousmenu` varchar(30) NOT NULL,
  `cocher` varchar(1) DEFAULT NULL,
  `nomfichier` varchar(30) DEFAULT NULL,
  `nomtable` varchar(30) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `importation`
--

INSERT INTO `importation` (`menu`, `sousmenu`, `cocher`, `nomfichier`, `nomtable`) VALUES
('Fichier', 'Affectation', '0', NULL, NULL),
('Fichier', 'Atelier', '0', NULL, NULL),
('Fichier', 'Banque', '0', NULL, NULL),
('Fichier', 'Chantier', '0', NULL, NULL),
('Fichier', 'Personnel', '0', NULL, NULL),
('Fichier', 'Qualification', '0', NULL, NULL),
('Fichier', 'Service', '0', NULL, NULL),
('Fichier', 'Sit, Administratif', '0', NULL, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `isfile`
--

CREATE TABLE `isfile` (
  `NTABLE` varchar(50) DEFAULT NULL,
  `CHAMP` varchar(50) DEFAULT NULL,
  `TAILLE` int(11) DEFAULT '0',
  `TYPEC` varchar(50) DEFAULT NULL,
  `vide` varchar(1) DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `isfile`
--

INSERT INTO `isfile` (`NTABLE`, `CHAMP`, `TAILLE`, `TYPEC`, `vide`) VALUES
('Affectation', 'CodAff', 3, 'dbText', '0'),
('Affectation', 'DesiAff', 30, 'dbText', '-'),
('Atelier', 'codatelier', 3, 'dbText', '0'),
('Atelier', 'libelleatelier', 30, 'dbText', '-'),
('AutrePoint', 'rubrique', 3, 'dbText', '0'),
('AutrePoint', 'libelle', 30, 'dbText', '-'),
('AutrePoint', 'montant', 4, 'dbSingle', '0'),
('AutrePoint', 'matr', 8, 'dbText', '0'),
('AutrePoint', 'nomprenom', 40, 'dbText', '-'),
('AutrePoint', 'codfich', 3, 'dbText', '0'),
('AutrePoint', 'codchantier', 3, 'dbText', '0'),
('AutrePoint', 'annee', 4, 'dbText', '0'),
('AutrePoint', 'mois', 12, 'dbText', '0'),
('AutrePoint', 'confirme', 1, 'dbBoolean', '0'),
('Banque', 'Codbanque', 15, 'dbText', '0'),
('Banque', 'numcompte', 20, 'dbText', '-'),
('Banque', 'Modele', 10, 'dbText', '-'),
('bpointage', 'annee', 4, 'dbText', '0'),
('bpointage', 'matricule', 8, 'dbText', '0'),
('bpointage', 'mois', 12, 'dbText', '0'),
('bpointage', 'nomprenom', 30, 'dbText', '-'),
('bpointage', 'taux1', 50, 'dbText', '-'),
('bpointage', 'taux2', 50, 'dbText', '-'),
('bpointage', 'taux3', 50, 'dbText', '-'),
('brouillardPoint', 'matr', 8, 'dbText', '0'),
('brouillardPoint', 'nomprenom', 30, 'dbText', '-'),
('brouillardPoint', 'jourtrv', 4, 'dbSingle', '0'),
('brouillardPoint', 'heureTrv', 4, 'dbSingle', '0'),
('brouillardPoint', 'jourcong', 4, 'dbSingle', '0'),
('brouillardPoint', 'jourfer', 4, 'dbSingle', '0'),
('brouillardPoint', 'codrub', 3, 'dbText', '-'),
('brouillardPoint', 'libelle', 30, 'dbText', '-'),
('brouillardPoint', 'nbrmontant', 4, 'dbSingle', '0'),
('brouillardPoint', 'mois', 12, 'dbText', '0'),
('brouillardPoint', 'annee', 4, 'dbText', '0'),
('brouillardPoint', 'codfich', 3, 'dbText', '0'),
('brouillardPoint', 'codchantier', 3, 'dbText', '0'),
('chantier', 'codchantier', 3, 'dbText', '0'),
('chantier', 'libelle', 30, 'dbText', '-'),
('CNT', 'Matr', 8, 'dbText', '-'),
('CNT', 'DateDeb', 8, 'dbDate', '0'),
('CNT', 'Datefin', 8, 'dbDate', '0'),
('CNT', 'Libelle', 40, 'dbText', '-'),
('CNT', 'Valid', 1, 'dbText', '-'),
('cond_for', 'valformule', 4, 'dbSingle', '0'),
('cond_for', 'valcondition', 1, 'dbBoolean', '0'),
('conge', 'code', 8, 'dbText', '0'),
('conge', 'payer', 3, 'dbText', '-'),
('conge', 'libelle', 30, 'dbText', '-'),
('conge', 'type', 10, 'dbText', '-'),
('conge', 'edition', 5, 'dbText', '-'),
('conge', 'AutreType', 30, 'dbText', '-'),
('ebp', 'fiche', 3, 'dbText', '0'),
('ebp', 'libelle', 30, 'dbText', '-'),
('ebp', 'annee', 4, 'dbText', '0'),
('ebp', 'mois', 12, 'dbText', '0'),
('ebp', 'nummois', 2, 'dbInteger', '0'),
('ebp', 'matricule', 8, 'dbText', '0'),
('ebp', 'nomprenom', 40, 'dbText', '-'),
('ebp', 'cnssste', 11, 'dbText', '-'),
('ebp', 'cnssempl', 11, 'dbText', '-'),
('ebp', 'categorie', 3, 'dbText', '-'),
('ebp', 'echelon', 2, 'dbText', '-'),
('ebp', 'sitf', 1, 'dbText', '-'),
('ebp', 'nbrenfant', 2, 'dbInteger', '0'),
('ebp', 'regime', 1, 'dbText', '-'),
('ebp', 'nomregime', 30, 'dbText', '-'),
('ebp', 'salb', 4, 'dbSingle', '0'),
('ebp', 'atl', 3, 'dbText', '-'),
('ebp', 'desiatl', 30, 'dbText', '-'),
('ebp', 'serv', 3, 'dbText', '-'),
('ebp', 'servdes', 30, 'dbText', '-'),
('ebp', 'qual', 3, 'dbText', '-'),
('ebp', 'qualdes', 30, 'dbText', '-'),
('ebp', 'aff', 3, 'dbText', '-'),
('ebp', 'affdes', 30, 'dbText', '-'),
('ebp', 'tit', 3, 'dbText', '-'),
('ebp', 'titdes', 30, 'dbText', '-'),
('ebp', 'jhtrv', 4, 'dbSingle', '0'),
('ebp', 'jcong', 4, 'dbSingle', '0'),
('ebp', 'jfer', 4, 'dbSingle', '0'),
('ebp', 'habs', 4, 'dbSingle', '0'),
('ebp', 'salbase', 4, 'dbSingle', '0'),
('ebp', 'toths', 4, 'dbSingle', '0'),
('ebp', 'totprime', 4, 'dbSingle', '0'),
('ebp', 'salbrut', 4, 'dbSingle', '0'),
('ebp', 'cnss', 4, 'dbSingle', '0'),
('ebp', 'tauxcnss', 4, 'dbSingle', '0'),
('ebp', 'salimpo', 4, 'dbSingle', '0'),
('ebp', 'impot', 4, 'dbSingle', '0'),
('ebp', 'salnet', 4, 'dbSingle', '0'),
('ebp', 'netpaye', 4, 'dbSingle', '0'),
('ebp', 'txcnss', 4, 'dbSingle', '0'),
('ebp', 'txacctrv', 4, 'dbSingle', '0'),
('ebp', 'deccnss', 1, 'dbText', '-'),
('ebp', 'banquesoc', 15, 'dbText', '-'),
('ebp', 'modepaie', 8, 'dbText', '-'),
('ebp', 'codeint', 1, 'dbText', '-'),
('ebp', 'valcong', 4, 'dbSingle', '0'),
('ebp', 'valferie', 4, 'dbSingle', '0'),
('ebp', 'autres', 8, 'dbDouble', '0'),
('ebp', 'TXCNAM', 8, 'dbDouble', '0'),
('ebp', 'TAUXCNAM', 8, 'dbDouble', '0'),
('ebp', 'CNAM', 8, 'dbDouble', '0'),
('ebptemp', 'fiche', 3, 'dbText', '0'),
('ebptemp', 'libelle', 30, 'dbText', '-'),
('ebptemp', 'annee', 4, 'dbText', '0'),
('ebptemp', 'mois', 12, 'dbText', '0'),
('ebptemp', 'nummois', 2, 'dbInteger', '0'),
('ebptemp', 'matricule', 8, 'dbText', '0'),
('ebptemp', 'nomprenom', 40, 'dbText', '-'),
('ebptemp', 'cnssste', 11, 'dbText', '-'),
('ebptemp', 'cnssempl', 11, 'dbText', '-'),
('ebptemp', 'categorie', 3, 'dbText', '-'),
('ebptemp', 'echelon', 2, 'dbText', '-'),
('ebptemp', 'sitf', 1, 'dbText', '-'),
('ebptemp', 'nbrenfant', 2, 'dbInteger', '0'),
('ebptemp', 'regime', 1, 'dbText', '-'),
('ebptemp', 'nomregime', 30, 'dbText', '-'),
('ebptemp', 'salb', 4, 'dbSingle', '0'),
('ebptemp', 'atl', 3, 'dbText', '-'),
('ebptemp', 'desiatl', 30, 'dbText', '-'),
('ebptemp', 'serv', 3, 'dbText', '-'),
('ebptemp', 'servdes', 30, 'dbText', '-'),
('ebptemp', 'qual', 3, 'dbText', '-'),
('ebptemp', 'qualdes', 30, 'dbText', '-'),
('ebptemp', 'aff', 3, 'dbText', '-'),
('ebptemp', 'affdes', 30, 'dbText', '-'),
('ebptemp', 'tit', 3, 'dbText', '-'),
('ebptemp', 'titdes', 30, 'dbText', '-'),
('ebptemp', 'jhtrv', 4, 'dbSingle', '0'),
('ebptemp', 'jcong', 4, 'dbSingle', '0'),
('ebptemp', 'jfer', 4, 'dbSingle', '0'),
('ebptemp', 'habs', 4, 'dbSingle', '0'),
('ebptemp', 'salbase', 4, 'dbSingle', '0'),
('ebptemp', 'toths', 4, 'dbSingle', '0'),
('ebptemp', 'totprime', 4, 'dbSingle', '0'),
('ebptemp', 'salbrut', 4, 'dbSingle', '0'),
('ebptemp', 'cnss', 4, 'dbSingle', '0'),
('ebptemp', 'tauxcnss', 4, 'dbSingle', '0'),
('ebptemp', 'salimpo', 4, 'dbSingle', '0'),
('ebptemp', 'impot', 4, 'dbSingle', '0'),
('ebptemp', 'salnet', 4, 'dbSingle', '0'),
('ebptemp', 'netpaye', 4, 'dbSingle', '0'),
('ebptemp', 'txcnss', 4, 'dbSingle', '0'),
('ebptemp', 'txacctrv', 4, 'dbSingle', '0'),
('ebptemp', 'deccnss', 1, 'dbText', '-'),
('ebptemp', 'banquesoc', 15, 'dbText', '-'),
('ebptemp', 'modepaie', 8, 'dbText', '-'),
('ebptemp', 'codeint', 1, 'dbText', '-'),
('ebptemp', 'valcong', 4, 'dbSingle', '0'),
('ebptemp', 'valferie', 4, 'dbSingle', '0'),
('ebptemp', 'autres', 8, 'dbDouble', '0'),
('ebptemp', 'TXCNAM', 8, 'dbDouble', '0'),
('ebptemp', 'TAUXCNAM', 8, 'dbDouble', '0'),
('ebptemp', 'CNAM', 8, 'dbDouble', '0'),
('ecn', 'annee', 4, 'dbText', '0'),
('ecn', 'trimestre', 1, 'dbText', '0'),
('ecn', 'txcotss', 4, 'dbSingle', '0'),
('ecn', 'datearrive', 10, 'dbText', '-'),
('ecn', 'modepaye', 15, 'dbText', '-'),
('ecn', 'montant', 8, 'dbDouble', '0'),
('ecn', 'caissele', 15, 'dbText', '-'),
('ecn', 'chequedu', 15, 'dbText', '-'),
('ecn', 'banque', 15, 'dbText', '-'),
('ecn', 'virement', 15, 'dbText', '-'),
('ecn', 'mandat', 15, 'dbText', '-'),
('ecn', 'saldecss', 8, 'dbDouble', '0'),
('ecn', 'saldecact', 8, 'dbDouble', '0'),
('ecn', 'txcotact', 4, 'dbSingle', '0'),
('ecn', 'nbsalarie', 2, 'dbInteger', '0'),
('ecn', 'total', 8, 'dbDouble', '0'),
('entpointage', 'codfich', 3, 'dbText', '0'),
('entpointage', 'codchantier', 3, 'dbText', '-'),
('entpointage', 'annee', 4, 'dbText', '0'),
('entpointage', 'mois', 12, 'dbText', '0'),
('entpointage', 'nummois', 2, 'dbInteger', '0'),
('entpointage', 'Generer', 1, 'dbText', '-'),
('fich', 'codfich', 3, 'dbText', '0'),
('fich', 'libelle', 40, 'dbText', '-'),
('fich', 'datclot', 10, 'dbText', '-'),
('fpointage', 'annee', 4, 'dbText', '0'),
('fpointage', 'matricule', 8, 'dbText', '0'),
('fpointage', 'mois', 12, 'dbText', '0'),
('fpointage', 'nomprenom', 30, 'dbText', '-'),
('grille', 'categorie', 3, 'dbText', '0'),
('grille', 'echelon', 2, 'dbText', '0'),
('grille', 'regime', 1, 'dbText', '0'),
('grille', 'ancumule', 2, 'dbText', '-'),
('grille', 'durechelon', 2, 'dbText', '-'),
('grille', 'salaire', 4, 'dbSingle', '0'),
('grille', 'tauxhor', 4, 'dbSingle', '0'),
('Grillesalaire', 'ancumule', 2, 'dbText', '-'),
('Grillesalaire', 'categorie', 3, 'dbText', '0'),
('Grillesalaire', 'durechelon', 2, 'dbText', '-'),
('Grillesalaire', 'durechelle', 2, 'dbText', '0'),
('Grillesalaire', 'echelle', 2, 'dbText', '-'),
('Grillesalaire', 'echelon', 2, 'dbText', '0'),
('Grillesalaire', 'regime', 1, 'dbText', '0'),
('Grillesalaire', 'salaire', 2, 'dbInteger', '0'),
('Grillesalaire', 'tauxhor', 2, 'dbInteger', '0'),
('heursupp', 'codheursupp', 1, 'dbText', '0'),
('heursupp', 'taux', 2, 'dbInteger', '0'),
('heursupp', 'libelle', 30, 'dbText', '-'),
('heursupp', 'nbrheursupp', 4, 'dbSingle', '0'),
('heursupp', 'codfich', 3, 'dbText', '0'),
('heursupp', 'codchantier', 3, 'dbText', '0'),
('heursupp', 'annee', 4, 'dbText', '0'),
('heursupp', 'mois', 12, 'dbText', '0'),
('heursupp', 'matr', 8, 'dbText', '0'),
('heursupp', 'nomprenom', 40, 'dbText', '-'),
('heursupp', 'confirme', 1, 'dbBoolean', '0'),
('historiquepret', 'code', 2, 'dbText', '0'),
('historiquepret', 'designa', 30, 'dbText', '-'),
('historiquepret', 'date1ret', 8, 'dbText', '-'),
('historiquepret', 'datepret', 8, 'dbText', '-'),
('historiquepret', 'blocage', 1, 'dbText', '-'),
('historiquepret', 'matricule', 8, 'dbText', '0'),
('historiquepret', 'nomprenom', 30, 'dbText', '-'),
('historiquepret', 'montret', 4, 'dbSingle', '0'),
('historiquepret', 'montpret', 4, 'dbSingle', '0'),
('historiquepret', 'montrest', 4, 'dbSingle', '0'),
('historiquepret', 'fiche', 3, 'dbText', '-'),
('historiquepret', 'desifich', 30, 'dbText', '-'),
('lbp', 'nbr', 2, 'dbInteger', '0'),
('lbp', 'fiche', 3, 'dbText', '0'),
('lbp', 'annee', 4, 'dbText', '0'),
('lbp', 'mois', 12, 'dbText', '0'),
('lbp', 'matricule', 8, 'dbText', '0'),
('lbp', 'rubrique', 3, 'dbText', '-'),
('lbp', 'libelle', 30, 'dbText', '-'),
('lbp', 'nombre', 4, 'dbSingle', '0'),
('lbp', 'retenue', 4, 'dbSingle', '0'),
('lbp', 'gain', 4, 'dbSingle', '0'),
('lbp', 'imposable', 1, 'dbText', '-'),
('lbp', 'cotisable', 1, 'dbText', '-'),
('lbptemp', 'nbr', 2, 'dbInteger', '0'),
('lbptemp', 'fiche', 3, 'dbText', '0'),
('lbptemp', 'annee', 4, 'dbText', '0'),
('lbptemp', 'mois', 12, 'dbText', '0'),
('lbptemp', 'matricule', 8, 'dbText', '0'),
('lbptemp', 'rubrique', 3, 'dbText', '-'),
('lbptemp', 'libelle', 30, 'dbText', '-'),
('lbptemp', 'nombre', 4, 'dbSingle', '0'),
('lbptemp', 'retenue', 4, 'dbSingle', '0'),
('lbptemp', 'gain', 4, 'dbSingle', '0'),
('lbptemp', 'imposable', 1, 'dbText', '-'),
('lbptemp', 'cotisable', 1, 'dbText', '-'),
('lcn', 'annee', 4, 'dbText', '0'),
('lcn', 'trimestre', 1, 'dbText', '0'),
('lcn', 'txcot', 4, 'dbSingle', '0'),
('lcn', 'numcnss', 11, 'dbText', '-'),
('lcn', 'matricule', 8, 'dbText', '0'),
('lcn', 'mois1', 4, 'dbSingle', '0'),
('lcn', 'mois2', 4, 'dbSingle', '0'),
('lcn', 'mois3', 4, 'dbSingle', '0'),
('lcn', 'page', 4, 'dbLong', '0'),
('lcn', 'numerordre', 4, 'dbLong', '0'),
('lcn', 'nomprenom', 30, 'dbText', '-'),
('lcn', 'categorie', 3, 'dbText', '-'),
('lignepointage', 'Matr', 8, 'dbText', '-'),
('lignepointage', 'Nomprenom', 40, 'dbText', '-'),
('lignepointage', 'regime', 1, 'dbText', '-'),
('lignepointage', 'jourtrv', 4, 'dbSingle', '0'),
('lignepointage', 'heuretrv', 4, 'dbSingle', '0'),
('lignepointage', 'Jourcong', 4, 'dbSingle', '0'),
('lignepointage', 'jourfer', 4, 'dbSingle', '0'),
('lignepointage', 'codfich', 3, 'dbText', '0'),
('lignepointage', 'codchantier', 3, 'dbText', '-'),
('lignepointage', 'annee', 4, 'dbText', '0'),
('lignepointage', 'mois', 12, 'dbText', '0'),
('lignepointage', 'confirme', 1, 'dbBoolean', '0'),
('ligneprime', 'rubrique', 3, 'dbText', '0'),
('ligneprime', 'designarub', 30, 'dbText', '-'),
('ligneprime', 'montant', 4, 'dbSingle', '0'),
('ligneprime', 'matr', 8, 'dbText', '0'),
('ligneprime', 'confirme', 1, 'dbBoolean', '0'),
('lignerub', 'codrubrique', 3, 'dbText', '0'),
('lignerub', 'condition', 78, 'dbText', '0'),
('lignerub', 'Formule', 78, 'dbText', '-'),
('lignerub', 'confirme', 1, 'dbText', '-'),
('lignerub', 'Ligne', 4, 'dbLong', '0'),
('majconge', 'code', 6, 'dbText', '0'),
('majconge', 'libelle', 30, 'dbText', '-'),
('majconge', 'type', 10, 'dbText', '-'),
('majconge', 'nbrjour', 4, 'dbSingle', '0'),
('majconge', 'nbrheure', 4, 'dbSingle', '0'),
('majconge', 'matricule', 8, 'dbText', '0'),
('majconge', 'nomprenom', 30, 'dbText', '-'),
('majconge', 'solde', 4, 'dbSingle', '0'),
('majconge', 'datedepart', 8, 'dbDate', '0'),
('majconge', 'datefin', 8, 'dbDate', '0'),
('majconge', 'payer', 3, 'dbText', '-'),
('majpret', 'code', 2, 'dbText', '0'),
('majpret', 'designa', 30, 'dbText', '-'),
('majpret', 'date1ret', 8, 'dbDate', '0'),
('majpret', 'datepret', 8, 'dbDate', '0'),
('majpret', 'blocage', 1, 'dbText', '-'),
('majpret', 'matricule', 8, 'dbText', '0'),
('majpret', 'nomprenom', 30, 'dbText', '-'),
('majpret', 'montret', 4, 'dbSingle', '0'),
('majpret', 'montpret', 4, 'dbSingle', '0'),
('majpret', 'montrest', 4, 'dbSingle', '0'),
('majpret', 'fiche', 3, 'dbText', '-'),
('majpret', 'desifich', 30, 'dbText', '-'),
('majpret', 'dated', 8, 'dbDate', '0'),
('majpret', 'datef', 8, 'dbDate', '0'),
('majpret', 'MontInit', 4, 'dbSingle', '0'),
('nbrjour', 'nbrJour', 2, 'dbInteger', '0'),
('nbrjour', 'matricule', 8, 'dbText', '0'),
('nbrjour', 'nomjour', 50, 'dbText', '-'),
('personnel', 'MATR', 8, 'dbText', '0'),
('personnel', 'CAISSE', 1, 'dbText', '-'),
('personnel', 'ECHELON', 2, 'dbText', '-'),
('personnel', 'PAYEMENT', 8, 'dbText', '-'),
('personnel', 'NATIONAL', 1, 'dbText', '-'),
('personnel', 'TRV_AN', 2, 'dbInteger', '0'),
('personnel', 'NOMPRENOM1', 30, 'dbText', '-'),
('personnel', 'PRENOM1', 20, 'dbText', '-'),
('personnel', 'PRENOM2', 20, 'dbText', '-'),
('personnel', 'PRENOM3', 20, 'dbText', '-'),
('personnel', 'PRENOM4', 20, 'dbText', '-'),
('personnel', 'NBRENFANT', 2, 'dbInteger', '0'),
('personnel', 'CIN', 10, 'dbText', '-'),
('personnel', 'NUMCNSS', 11, 'dbText', '-'),
('personnel', 'SERV', 3, 'dbText', '-'),
('personnel', 'REGIME2', 2, 'dbText', '-'),
('personnel', 'REGIME1', 1, 'dbText', '-'),
('personnel', 'nomregime1', 30, 'dbText', '-'),
('personnel', 'SALB', 4, 'dbSingle', '0'),
('personnel', 'TIT', 3, 'dbText', '-'),
('personnel', 'SITF', 1, 'dbText', '-'),
('personnel', 'TXHOR', 4, 'dbSingle', '0'),
('personnel', 'TXCNSS', 4, 'dbSingle', '0'),
('personnel', 'TELEPHONE', 10, 'dbText', '-'),
('personnel', 'NOMPRENOM2', 30, 'dbText', '-'),
('personnel', 'BANQUESTE', 15, 'dbText', '-'),
('personnel', 'BANQUEPER', 15, 'dbText', '-'),
('personnel', 'numcompte', 20, 'dbText', '-'),
('personnel', 'DECIMPOT', 1, 'dbText', '-'),
('personnel', 'ARR1', 2, 'dbInteger', '0'),
('personnel', 'COMPTEC', 8, 'dbText', '-'),
('personnel', 'ATELIER', 3, 'dbText', '-'),
('personnel', 'ADRESSE', 40, 'dbText', '-'),
('personnel', 'CAT', 3, 'dbText', '-'),
('personnel', 'CHEF', 1, 'dbText', '-'),
('personnel', 'PRESENCE', 1, 'dbText', '-'),
('personnel', 'QUAL', 3, 'dbText', '-'),
('personnel', 'AFF', 3, 'dbText', '-'),
('personnel', 'SEXE', 1, 'dbText', '-'),
('personnel', 'DATECHE', 8, 'dbDate', '0'),
('personnel', 'PROCHEECHE', 8, 'dbDate', '0'),
('personnel', 'EMBO', 8, 'dbDate', '0'),
('personnel', 'NAIS', 8, 'dbDate', '0'),
('personnel', 'ACCtrv', 1, 'dbText', '-'),
('personnel', 'DATESIT', 8, 'dbDate', '0'),
('personnel', 'NAIS1', 10, 'dbText', '-'),
('personnel', 'NAIS2', 10, 'dbText', '-'),
('personnel', 'NAIS3', 10, 'dbText', '-'),
('personnel', 'NAIS4', 10, 'dbText', '-'),
('personnel', 'imagepersonnel', 200, 'dbText', '-'),
('personnel', 'SMIG', 1, 'dbText', '-'),
('personnel', 'SUPH', 8, 'dbText', '-'),
('personnel', 'DATECIN', 8, 'dbDate', '0'),
('personnel', 'SoldInit', 8, 'dbDouble', '0'),
('personnel', 'DroitCong', 8, 'dbDouble', '0'),
('personnel', 'Total', 8, 'dbDouble', '0'),
('PrimePers', 'MATR', 8, 'dbText', '0'),
('PrimePers', 'codRUBRIQUE', 3, 'dbText', '0'),
('PrimePers', 'MONTANT', 2, 'dbInteger', '0'),
('Qualification', 'codequalif', 3, 'dbText', '0'),
('Qualification', 'qualificat', 30, 'dbText', '-'),
('rubrique', 'codrubrique', 3, 'dbText', '0'),
('rubrique', 'designarub', 30, 'dbText', '-'),
('rubrique', 'libelle', 8, 'dbText', '-'),
('rubrique', 'ncompte', 8, 'dbText', '-'),
('rubrique', 'type', 3, 'dbText', '-'),
('rubrique', 'nature', 7, 'dbText', '-'),
('rubrique', 'imposable', 1, 'dbText', '-'),
('rubrique', 'cotisable', 1, 'dbText', '-'),
('rubrique', 'regime', 1, 'dbText', '-'),
('service', 'codservice', 3, 'dbText', '0'),
('service', 'designaser', 30, 'dbText', '-'),
('situationadmin', 'codesit', 3, 'dbText', '0'),
('situationadmin', 'sitadminis', 30, 'dbText', '-'),
('Societe', 'CODSOC', 5, 'dbText', '0'),
('Societe', 'NOMSOCI', 20, 'dbText', '0'),
('Societe', 'ADRESSE', 100, 'dbText', '-'),
('Societe', 'NBUREAU', 2, 'dbText', '-'),
('Societe', 'CODETVA', 20, 'dbText', '-'),
('Societe', 'CODPOSTAL', 4, 'dbText', '-'),
('Societe', 'CODUSE', 1, 'dbBoolean', '0'),
('Societe', 'DATCLOT', 10, 'dbText', '0'),
('Societe', 'DIRECTEUR', 30, 'dbText', '-'),
('Societe', 'FOPROLOS', 4, 'dbSingle', '0'),
('Societe', 'NUMCNSS', 11, 'dbText', '-'),
('Societe', 'TFP', 4, 'dbSingle', '0'),
('Societe', 'ACCTRV', 4, 'dbSingle', '0'),
('Societe', 'TXEMPLOYEUR', 4, 'dbSingle', '0'),
('Societe', 'TXEMPLOYER', 4, 'dbSingle', '0'),
('Societe', 'TELEFAX', 15, 'dbText', '-'),
('Societe', 'TELEX', 15, 'dbText', '-'),
('Societe', 'TELEPHONE', 31, 'dbText', '-'),
('Societe', 'VILLE', 15, 'dbText', '-'),
('Societe', 'MODELE', 1, 'dbText', '-'),
('Societe', 'TXARRONDI', 4, 'dbSingle', '0'),
('Societe', 'TYPEIRPP', 1, 'dbText', '-'),
('Societe', 'jnormal', 4, 'dbSingle', '0'),
('Societe', 'hnormal', 4, 'dbSingle', '0'),
('Societe', 'clotfiches', 20, 'dbText', '-'),
('tempautrepoint', 'rubrique', 3, 'dbText', '0'),
('tempautrepoint', 'libelle', 30, 'dbText', '-'),
('tempautrepoint', 'montant', 4, 'dbSingle', '0'),
('tempautrepoint', 'matr', 8, 'dbText', '0'),
('tempautrepoint', 'nomprenom', 40, 'dbText', '-'),
('tempautrepoint', 'codfich', 3, 'dbText', '0'),
('tempautrepoint', 'codchantier', 3, 'dbText', '0'),
('tempautrepoint', 'annee', 4, 'dbText', '0'),
('tempautrepoint', 'mois', 12, 'dbText', '0'),
('tempautrepoint', 'confirme', 1, 'dbBoolean', '0'),
('tempCot', 'annee', 4, 'dbText', '0'),
('tempCot', 'mois', 12, 'dbText', '0'),
('tempCot', 'txcot', 8, 'dbDouble', '0'),
('tempCot', 'matricule', 8, 'dbText', '0'),
('tempCot', 'fiche', 3, 'dbText', '0'),
('tempCot', 'salbrut', 8, 'dbDouble', '0'),
('tempCot', 'nomprenom', 30, 'dbText', '-'),
('tempCot', 'numcnss', 11, 'dbText', '-'),
('tempCot', 'categorie', 3, 'dbText', '-'),
('tempheursupp', 'codheursupp', 1, 'dbText', '0'),
('tempheursupp', 'taux', 2, 'dbInteger', '0'),
('tempheursupp', 'libelle', 30, 'dbText', '-'),
('tempheursupp', 'nbrheursupp', 4, 'dbSingle', '0'),
('tempheursupp', 'codfich', 3, 'dbText', '0'),
('tempheursupp', 'codchantier', 3, 'dbText', '0'),
('tempheursupp', 'annee', 4, 'dbText', '0'),
('tempheursupp', 'mois', 12, 'dbText', '0'),
('tempheursupp', 'matr', 8, 'dbText', '0'),
('tempheursupp', 'nomprenom', 40, 'dbText', '-'),
('tempheursupp', 'confirme', 1, 'dbBoolean', '0'),
('Templignepointage', 'Matr', 8, 'dbText', '-'),
('Templignepointage', 'Nomprenom', 40, 'dbText', '-'),
('Templignepointage', 'regime', 1, 'dbText', '-'),
('Templignepointage', 'jourtrv', 4, 'dbSingle', '0'),
('Templignepointage', 'heuretrv', 4, 'dbSingle', '0'),
('Templignepointage', 'Jourcong', 4, 'dbSingle', '0'),
('Templignepointage', 'jourfer', 4, 'dbSingle', '0'),
('Templignepointage', 'codfich', 3, 'dbText', '0'),
('Templignepointage', 'codchantier', 3, 'dbText', '-'),
('Templignepointage', 'annee', 4, 'dbText', '0'),
('Templignepointage', 'mois', 12, 'dbText', '0'),
('Templignepointage', 'confirme', 1, 'dbBoolean', '0'),
('templigneprime', 'rubrique', 3, 'dbText', '0'),
('templigneprime', 'designarub', 30, 'dbText', '-'),
('templigneprime', 'montant', 4, 'dbSingle', '0'),
('templigneprime', 'matr', 8, 'dbText', '0'),
('templigneprime', 'confirme', 1, 'dbBoolean', '0'),
('templignerub', 'codrubrique', 3, 'dbText', '0'),
('templignerub', 'condition', 78, 'dbText', '0'),
('templignerub', 'Formule', 78, 'dbText', '-'),
('templignerub', 'confirme', 1, 'dbText', '-'),
('templignerub', 'ligne', 4, 'dbLong', '0'),
('tempmajconge', 'code', 6, 'dbText', '0'),
('tempmajconge', 'libelle', 30, 'dbText', '-'),
('tempmajconge', 'type', 10, 'dbText', '-'),
('tempmajconge', 'nbrjour', 4, 'dbSingle', '0'),
('tempmajconge', 'nbrheure', 4, 'dbSingle', '0'),
('tempmajconge', 'matricule', 8, 'dbText', '0'),
('tempmajconge', 'nomprenom', 30, 'dbText', '-'),
('tempmajconge', 'solde', 4, 'dbSingle', '0'),
('tempmajconge', 'datedepart', 10, 'dbDate', '0'),
('tempmajconge', 'datefin', 10, 'dbDate', '0'),
('tempmajconge', 'payer', 3, 'dbText', '-'),
('THS', 'codths', 1, 'dbText', '0'),
('THS', 'libelle', 30, 'dbText', '-'),
('THS', 'taux', 2, 'dbInteger', '0'),
('tmpPers', 'matr', 8, 'dbText', '0'),
('tmpPers', 'nomprenom1', 30, 'dbText', '0'),
('tmpPers', 'qualification', 30, 'dbText', '0'),
('tmpPers', 'Prenom', 30, 'dbText', '0'),
('tmpPers', 'naissance', 8, 'dbDate', '0'),
('variable', 'codVariable', 10, 'dbText', '0'),
('variable', 'Libelle', 30, 'dbText', '-'),
('Vnote', 'matricule', 8, 'dbText', '0'),
('Vnote', 'annee', 4, 'dbText', '0'),
('Vnote', 'mois', 2, 'dbText', '0'),
('Vnote', 'note_rend', 4, 'dbSingle', '0'),
('Vnote', 'note_prod', 2, 'dbInteger', '0'),
('Vnote', 'nomprenom', 30, 'dbText', '-'),
('TmpEntPointage', NULL, 0, NULL, '0'),
('pointjour', 'codfich', 3, 'dbText', '0'),
('pointjour', 'codchan', 3, 'dbText', '0'),
('pointjour', 'annee', 4, 'dbText', '0'),
('pointjour', 'mois', 12, 'dbText', '0'),
('pointjour', 'matricule', 8, 'dbText', '0'),
('pointjour', 'j1', 5, 'dbText', '-'),
('pointjour', 'j2', 5, 'dbText', '-'),
('pointjour', 'j3', 5, 'dbText', '-'),
('pointjour', 'j4', 5, 'dbText', '-'),
('pointjour', 'j5', 5, 'dbText', '-'),
('pointjour', 'j6', 5, 'dbText', '-'),
('pointjour', 'j7', 5, 'dbText', '-'),
('pointjour', 'j8', 5, 'dbText', '-'),
('pointjour', 'j9', 5, 'dbText', '-'),
('pointjour', 'j10', 5, 'dbText', '-'),
('pointjour', 'j11', 5, 'dbText', '-'),
('pointjour', 'j12', 5, 'dbText', '-'),
('pointjour', 'j13', 5, 'dbText', '-'),
('pointjour', 'j14', 5, 'dbText', '-'),
('pointjour', 'j15', 5, 'dbText', '-'),
('pointjour', 'j16', 5, 'dbText', '-'),
('pointjour', 'j17', 5, 'dbText', '-'),
('pointjour', 'j18', 5, 'dbText', '-'),
('pointjour', 'j19', 5, 'dbText', '-'),
('pointjour', 'j20', 5, 'dbText', '-'),
('pointjour', 'j21', 5, 'dbText', '-'),
('pointjour', 'j22', 5, 'dbText', '-'),
('pointjour', 'j23', 5, 'dbText', '-'),
('pointjour', 'j24', 5, 'dbText', '-'),
('pointjour', 'j25', 5, 'dbText', '-'),
('pointjour', 'j26', 5, 'dbText', '-'),
('pointjour', 'j27', 5, 'dbText', '-'),
('pointjour', 'j28', 5, 'dbText', '-'),
('pointjour', 'j29', 5, 'dbText', '-'),
('pointjour', 'j30', 5, 'dbText', '-'),
('pointjour', 'j31', 5, 'dbText', '-'),
('pointjour', 'totheure', 5, 'dbText', '-'),
('pointjour', 'totjour', 5, 'dbText', '-'),
('pointjour', 'salbase', 8, 'dbDouble', '0'),
('pointjour', 'totprime', 8, 'dbDouble', '0'),
('pointjour', 'salbrut', 8, 'dbDouble', '0'),
('pointjour', 'cnss', 8, 'dbDouble', '0'),
('pointjour', 'salimpo', 8, 'dbDouble', '0'),
('pointjour', 'impot', 8, 'dbDouble', '0'),
('pointjour', 'salnet', 8, 'dbDouble', '0'),
('nomjour', 'annee', 4, 'dbText', '-'),
('nomjour', 'mois', 20, 'dbText', '-'),
('nomjour', 'nbjour', 2, 'dbText', '-'),
('nomjour', 'nomjour', 12, 'dbText', '-'),
('poijourtmp', 'codfich', 3, 'dbText', '0'),
('poijourtmp', 'codchan', 3, 'dbText', '0'),
('poijourtmp', 'annee', 4, 'dbText', '0'),
('poijourtmp', 'mois', 12, 'dbText', '0'),
('poijourtmp', 'matricule', 8, 'dbText', '0'),
('poijourtmp', 'j1', 5, 'dbText', '-'),
('poijourtmp', 'j2', 5, 'dbText', '-'),
('poijourtmp', 'j3', 5, 'dbText', '-'),
('poijourtmp', 'j4', 5, 'dbText', '-'),
('poijourtmp', 'j5', 5, 'dbText', '-'),
('poijourtmp', 'j6', 5, 'dbText', '-'),
('poijourtmp', 'j7', 5, 'dbText', '-'),
('poijourtmp', 'j8', 5, 'dbText', '-'),
('poijourtmp', 'j9', 5, 'dbText', '-'),
('poijourtmp', 'j10', 5, 'dbText', '-'),
('poijourtmp', 'j11', 5, 'dbText', '-'),
('poijourtmp', 'j12', 5, 'dbText', '-'),
('poijourtmp', 'j13', 5, 'dbText', '-'),
('poijourtmp', 'j14', 5, 'dbText', '-'),
('poijourtmp', 'j15', 5, 'dbText', '-'),
('poijourtmp', 'j16', 5, 'dbText', '-'),
('poijourtmp', 'j17', 5, 'dbText', '-'),
('poijourtmp', 'j18', 5, 'dbText', '-'),
('poijourtmp', 'j19', 5, 'dbText', '-'),
('poijourtmp', 'j20', 5, 'dbText', '-'),
('poijourtmp', 'j21', 5, 'dbText', '-'),
('poijourtmp', 'j22', 5, 'dbText', '-'),
('poijourtmp', 'j23', 5, 'dbText', '-'),
('poijourtmp', 'j24', 5, 'dbText', '-'),
('poijourtmp', 'j25', 5, 'dbText', '-'),
('poijourtmp', 'j26', 5, 'dbText', '-'),
('poijourtmp', 'j27', 5, 'dbText', '-'),
('poijourtmp', 'j28', 5, 'dbText', '-'),
('poijourtmp', 'j29', 5, 'dbText', '-'),
('poijourtmp', 'j30', 5, 'dbText', '-'),
('poijourtmp', 'j31', 5, 'dbText', '-'),
('poijourtmp', 'totheure', 5, 'dbText', '-'),
('poijourtmp', 'totjour', 3, 'dbText', '-'),
('poijourtmp1', 'codfich', 3, 'dbText', '0'),
('poijourtmp1', 'codchan', 3, 'dbText', '0'),
('poijourtmp1', 'annee', 4, 'dbText', '0'),
('poijourtmp1', 'mois', 12, 'dbText', '0'),
('poijourtmp1', 'matricule', 8, 'dbText', '0'),
('poijourtmp1', 'j1', 5, 'dbText', '-'),
('poijourtmp1', 'j2', 5, 'dbText', '-'),
('poijourtmp1', 'j3', 5, 'dbText', '-'),
('poijourtmp1', 'j4', 5, 'dbText', '-'),
('poijourtmp1', 'j5', 5, 'dbText', '-'),
('poijourtmp1', 'j6', 5, 'dbText', '-'),
('poijourtmp1', 'j7', 5, 'dbText', '-'),
('poijourtmp1', 'j8', 5, 'dbText', '-'),
('poijourtmp1', 'j9', 5, 'dbText', '-'),
('poijourtmp1', 'j10', 5, 'dbText', '-'),
('poijourtmp1', 'j11', 5, 'dbText', '-'),
('poijourtmp1', 'j12', 5, 'dbText', '-'),
('poijourtmp1', 'j13', 5, 'dbText', '-'),
('poijourtmp1', 'j14', 5, 'dbText', '-'),
('poijourtmp1', 'j15', 5, 'dbText', '-'),
('poijourtmp1', 'j16', 5, 'dbText', '-'),
('poijourtmp1', 'j17', 5, 'dbText', '-'),
('poijourtmp1', 'j18', 5, 'dbText', '-'),
('poijourtmp1', 'j19', 5, 'dbText', '-'),
('poijourtmp1', 'j20', 5, 'dbText', '-'),
('poijourtmp1', 'j21', 5, 'dbText', '-'),
('poijourtmp1', 'j22', 5, 'dbText', '-'),
('poijourtmp1', 'j23', 5, 'dbText', '-'),
('poijourtmp1', 'j24', 5, 'dbText', '-'),
('poijourtmp1', 'j25', 5, 'dbText', '-'),
('poijourtmp1', 'j26', 5, 'dbText', '-'),
('poijourtmp1', 'j27', 5, 'dbText', '-'),
('poijourtmp1', 'j28', 5, 'dbText', '-'),
('poijourtmp1', 'j29', 5, 'dbText', '-'),
('poijourtmp1', 'j30', 5, 'dbText', '-'),
('poijourtmp1', 'j31', 5, 'dbText', '-'),
('poijourtmp1', 'totheure', 5, 'dbText', '-'),
('poijourtmp1', 'totjour', 5, 'dbText', '-'),
('mission', 'code', 7, 'dbText', '-'),
('mission', 'piece', 11, 'dbText', '-'),
('mission', 'codpers', 8, 'dbText', '-'),
('mission', 'nomprenom', 30, 'dbText', '-'),
('mission', 'codqual', 3, 'dbText', '-'),
('mission', 'qualification', 30, 'dbText', '-'),
('mission', 'objet', 255, 'dbText', '-'),
('mission', 'datedu', 8, 'dbDate', '0'),
('mission', 'dateau', 8, 'dbDate', '0'),
('mission', 'region', 30, 'dbText', '-'),
('mission', 'fraisestim', 8, 'dbDouble', '0'),
('mission', 'fraisreel', 8, 'dbDouble', '0'),
('mission', 'datecreat', 8, 'dbDate', '0');

-- --------------------------------------------------------

--
-- Structure de la table `menu`
--

CREATE TABLE `menu` (
  `menu` varchar(30) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `menu`
--

INSERT INTO `menu` (`menu`) VALUES
('Autres Traitements'),
('Congés'),
('Edition'),
('Fichier'),
('Pointages'),
('Prêts'),
('Traitement Mensuel'),
('Utilitaires');

-- --------------------------------------------------------

--
-- Structure de la table `menumotdepasse`
--

CREATE TABLE `menumotdepasse` (
  `menu` varchar(30) NOT NULL,
  `motdepasse` varchar(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `menumotdepasse`
--

INSERT INTO `menumotdepasse` (`menu`, `motdepasse`) VALUES
('...', 'E2E2E22EE22E2E2E'),
('cloture', '07D6D66DD6707070'),
('variable', '3333133323333333');

-- --------------------------------------------------------

--
-- Structure de la table `nomtable`
--

CREATE TABLE `nomtable` (
  `nomtable` varchar(30) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `nomtable`
--

INSERT INTO `nomtable` (`nomtable`) VALUES
('acceemodule__'),
('couleur'),
('importation'),
('isfile'),
('menu'),
('menumotdepasse'),
('nomtable'),
('numserie'),
('paramaitre'),
('size'),
('societe'),
('tmp'),
('usermodule'),
('usersoc'),
('utilisateur'),
('utilitaire');

-- --------------------------------------------------------

--
-- Structure de la table `numserie`
--

CREATE TABLE `numserie` (
  `numserie` varchar(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `numserie`
--

INSERT INTO `numserie` (`numserie`) VALUES
(NULL),
('3393343643383445'),
('3393343643383445');

-- --------------------------------------------------------

--
-- Structure de la table `paramaitre`
--

CREATE TABLE `paramaitre` (
  `compteuser` varchar(30) NOT NULL,
  `CODSOC` varchar(5) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `paramaitre`
--

INSERT INTO `paramaitre` (`compteuser`, `CODSOC`) VALUES
('400110', 'bb');

-- --------------------------------------------------------

--
-- Structure de la table `size`
--

CREATE TABLE `size` (
  `oldw` int(11) NOT NULL DEFAULT '0',
  `oldh` int(11) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `size`
--

INSERT INTO `size` (`oldw`, `oldh`) VALUES
(12120, 8700);

-- --------------------------------------------------------

--
-- Structure de la table `societe`
--

CREATE TABLE `societe` (
  `CODSOC` varchar(12) NOT NULL,
  `NOMSOCI` varchar(50) DEFAULT NULL,
  `ADRESSE` varchar(100) DEFAULT NULL,
  `NBUREAU` varchar(2) DEFAULT NULL,
  `CODETVA` varchar(20) DEFAULT NULL,
  `CODPOSTAL` varchar(4) DEFAULT NULL,
  `CODUSE` varchar(1) DEFAULT '0',
  `DATCLOT` varchar(10) DEFAULT NULL,
  `DIRECTEUR` varchar(30) DEFAULT NULL,
  `FOPROLOS` float DEFAULT '0',
  `NUMCNSS` varchar(11) DEFAULT NULL,
  `TFP` float DEFAULT '0',
  `ACCTRV` float DEFAULT '0',
  `TXEMPLOYEUR` float DEFAULT '0',
  `TXEMPLOYER` float DEFAULT '0',
  `TELEFAX` varchar(15) DEFAULT NULL,
  `TELEX` varchar(15) DEFAULT NULL,
  `TELEPHONE` varchar(31) DEFAULT NULL,
  `VILLE` varchar(15) DEFAULT NULL,
  `MODELE` varchar(1) DEFAULT NULL,
  `TXARRONDI` float NOT NULL DEFAULT '0',
  `TYPEIRPP` varchar(1) DEFAULT NULL,
  `jnormal` float DEFAULT '0',
  `hnormal` float DEFAULT '0',
  `clotfiches` varchar(20) DEFAULT NULL,
  `CNAMEMPLOYEUR` double DEFAULT '0',
  `CNAMEMPLOYE` double DEFAULT '0',
  `hortra` varchar(1) DEFAULT NULL,
  `GUTIL` varchar(1) DEFAULT '0',
  `chantier` varchar(1) DEFAULT NULL,
  `nbrmois` int(11) DEFAULT '0',
  `pointrub` varchar(1) DEFAULT '0',
  `nbrheure` double DEFAULT NULL,
  `disquetcnss` varchar(1) DEFAULT '0',
  `suppbanque` varchar(1) DEFAULT '0',
  `liaison_pointeuse` varchar(1) DEFAULT NULL,
  `mtredevance` double DEFAULT NULL,
  `txredevance` varchar(3) DEFAULT NULL,
  `parampoint` varchar(1) DEFAULT '0',
  `Synchronisation` varchar(1) DEFAULT NULL,
  `majred` varchar(1) DEFAULT '0',
  `impotshs` varchar(1) DEFAULT '0',
  `sdconj` varchar(1) DEFAULT '0',
  `ParamRappel` varchar(1) DEFAULT '0',
  `calhmens` varchar(1) DEFAULT '0',
  `enthpoint` varchar(1) DEFAULT '0',
  `calmmens` varchar(1) DEFAULT '0',
  `sortcal` varchar(1) DEFAULT '0',
  `rue` varchar(72) DEFAULT NULL,
  `activite` varchar(40) DEFAULT NULL,
  `numero` varchar(4) DEFAULT NULL,
  `exercice` varchar(4) DEFAULT NULL,
  `codeacte` varchar(1) DEFAULT NULL,
  `TMAJO` varchar(1) DEFAULT NULL,
  `mf` varchar(20) DEFAULT NULL,
  `ParamAnn1` varchar(1) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `societe`
--

INSERT INTO `societe` (`CODSOC`, `NOMSOCI`, `ADRESSE`, `NBUREAU`, `CODETVA`, `CODPOSTAL`, `CODUSE`, `DATCLOT`, `DIRECTEUR`, `FOPROLOS`, `NUMCNSS`, `TFP`, `ACCTRV`, `TXEMPLOYEUR`, `TXEMPLOYER`, `TELEFAX`, `TELEX`, `TELEPHONE`, `VILLE`, `MODELE`, `TXARRONDI`, `TYPEIRPP`, `jnormal`, `hnormal`, `clotfiches`, `CNAMEMPLOYEUR`, `CNAMEMPLOYE`, `hortra`, `GUTIL`, `chantier`, `nbrmois`, `pointrub`, `nbrheure`, `disquetcnss`, `suppbanque`, `liaison_pointeuse`, `mtredevance`, `txredevance`, `parampoint`, `Synchronisation`, `majred`, `impotshs`, `sdconj`, `ParamRappel`, `calhmens`, `enthpoint`, `calmmens`, `sortcal`, `rue`, `activite`, `numero`, `exercice`, `codeacte`, `TMAJO`, `mf`, `ParamAnn1`) VALUES
('grpaie', 'societe 1', 'RTE LAFRAN KLM 4 SFAX', '', '1190684E/P/M000', '', '0', '0000-00-00', '', 1, '317753-78', 1, 1.6, 16.57, 9.18, '___-(__)-______', '0', '___-(__)-______/___-(__)-______', 'SFAX', '', 1, '1', 26, 208, 'Décembre  2021', 0, 0, '0', '0', '0', 13, '0', 8, '1', '0', '0', 0, '', '0', '0', '0', '0', '0', '1', '0', '1', '0', '0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0'),
('grpaie2', 'societe 2', '', '', '', '', '0', '__/__/____', '', 1, '', 2, 1, 16.57, 9.18, '___-(__)-______', '0', '___-(__)-______/___-(__)-______', '', '', 1, '1', 26, 208, '', 0, 0, '0', '0', NULL, 12, '0', 8, '0', '0', NULL, 0, '', '0', NULL, '0', '0', '0', '0', '0', '0', '0', '0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
('grpaie1', 'societe 3', '', '', '', '', '0', '__/__/____', '', 1, '', 2, 1, 16.57, 9.18, '___-(__)-______', '0', '___-(__)-______/___-(__)-______', '', '', 1, '1', 26, 208, '', 0, 0, '0', '0', NULL, 12, '0', 8, '0', '0', NULL, 0, '', '0', NULL, '0', '0', '0', '0', '0', '0', '0', '0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `tmp`
--

CREATE TABLE `tmp` (
  `N°` int(11) NOT NULL,
  `module` varchar(50) DEFAULT NULL,
  `accee` varchar(1) DEFAULT '0',
  `societe` varchar(8) DEFAULT NULL,
  `ajouter` varchar(1) DEFAULT '0',
  `SUPPRIMER` varchar(1) DEFAULT '0',
  `MODIFIER` varchar(1) DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `usermodule`
--

CREATE TABLE `usermodule` (
  `codeuser` varchar(50) DEFAULT NULL,
  `module` varchar(50) DEFAULT NULL,
  `accee` varchar(1) DEFAULT '0',
  `ecriture` varchar(1) DEFAULT '0',
  `societe` varchar(8) DEFAULT NULL,
  `AJOUTER` varchar(1) DEFAULT '0',
  `supprimer` varchar(1) DEFAULT '0',
  `MODIFIER` varchar(1) DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `usersoc`
--

CREATE TABLE `usersoc` (
  `CODEUSER` varchar(50) NOT NULL DEFAULT '',
  `societe` varchar(8) NOT NULL DEFAULT '',
  `accee` varchar(1) DEFAULT '0',
  `ecriture` varchar(1) DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `usersoc`
--

INSERT INTO `usersoc` (`CODEUSER`, `societe`, `accee`, `ecriture`) VALUES
('00', 'grpaie', '1', '0'),
('00', 'grpaie2', '1', '0'),
('01', 'grpaie', '1', '0');

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

CREATE TABLE `utilisateur` (
  `compteuser` varchar(30) NOT NULL DEFAULT '',
  `motdepasse` varchar(10) NOT NULL,
  `DERSOC` varchar(12) DEFAULT NULL,
  `actif` varchar(1) DEFAULT '0',
  `numvol` varchar(12) DEFAULT '0',
  `type` varchar(12) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`compteuser`, `motdepasse`, `DERSOC`, `actif`, `numvol`, `type`) VALUES
('00', '00', 'grpaie2', '0', '', 'Superviseur'),
('01', '01', 'grpaie2', '1', 'C9480B20', 'Utilisateur'),
('02', '02', 'grpaie', '1', '8020583A', 'Personnel');

-- --------------------------------------------------------

--
-- Structure de la table `utilitaire`
--

CREATE TABLE `utilitaire` (
  `Code` varchar(10) NOT NULL,
  `Chemin` varchar(250) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `utilitaire`
--

INSERT INTO `utilitaire` (`Code`, `Chemin`) VALUES
('CAL', 'C:\\WINDOWS\\system32\\calc.exe'),
('EX', 'C:\\Program Files\\Microsoft Office\\Office10\\EXCEL.EXE'),
('GF', 'C:\\WINDOWS\\Explorer.exe'),
('ODBC', 'C:\\WINDOWS\\system32\\odbcad32.exe'),
('PC', 'C:\\Program Files\\pcANYWHERE\\Winaw32.exe'),
('TT', 'C:\\Program Files\\Microsoft Office\\Office10\\WINWORD.EXE'),
('winzip', 'C:\\Program Files\\WinZip\\WINZIP32.EXE');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `couleur`
--
ALTER TABLE `couleur`
  ADD PRIMARY KEY (`couleur1`);

--
-- Index pour la table `importation`
--
ALTER TABLE `importation`
  ADD PRIMARY KEY (`menu`,`sousmenu`);

--
-- Index pour la table `menu`
--
ALTER TABLE `menu`
  ADD PRIMARY KEY (`menu`);

--
-- Index pour la table `menumotdepasse`
--
ALTER TABLE `menumotdepasse`
  ADD PRIMARY KEY (`menu`,`motdepasse`);

--
-- Index pour la table `paramaitre`
--
ALTER TABLE `paramaitre`
  ADD PRIMARY KEY (`compteuser`,`CODSOC`);

--
-- Index pour la table `size`
--
ALTER TABLE `size`
  ADD PRIMARY KEY (`oldw`,`oldh`);

--
-- Index pour la table `societe`
--
ALTER TABLE `societe`
  ADD PRIMARY KEY (`CODSOC`);

--
-- Index pour la table `tmp`
--
ALTER TABLE `tmp`
  ADD PRIMARY KEY (`N°`);

--
-- Index pour la table `usersoc`
--
ALTER TABLE `usersoc`
  ADD PRIMARY KEY (`CODEUSER`,`societe`);

--
-- Index pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  ADD PRIMARY KEY (`compteuser`);

--
-- Index pour la table `utilitaire`
--
ALTER TABLE `utilitaire`
  ADD PRIMARY KEY (`Code`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
