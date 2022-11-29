# Force migration to the cofiguration folder
Add-Migration 001 -OutputDir "Configurations/Migrations"

Add-Migration 002

#Mise à jour de la BD pour une migration ciblée
Update-Database -Migration 001

#Génération du script sql de passage d'une migration à une autre.
Script-Migration -From 001 -To 002 -Output script_002.sql

Script-Migration -From 004 -To 005 -Output script_005.sql

#Déploiement avec kestrel
#Connexion
##1-	Methode de publication : systeme de fichiers
##2-	Emplacement cible : D:\Sih
#Paramètre
##3-	Configuration : release
##4-	Infrastructure cible : net5.0
##5-	Mode de déploiement : autonome
##6-	Runtime cible : win-x64
##7-	Option de publication de fichiers : laisser vide
##8-	Base de données : laisser vide
##9-	Migration Entity Framework : laisser vide

#Etant sur le serveur cible : 
##1- entrer la bonne chaine de connexion dans le fichier "appsettings.json"
##2-	exécuter dans le repertoire du projet la cmd suivante
###ePatrimoine.WUI.exe --urls http://adresseIP:Port
Sih.Web.exe --urls http://192.168.0.31:81

