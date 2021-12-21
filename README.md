# zpmini_ref
[Micah Bredenhorst]

Bijgeleverd is een docker-compose bestand voor het uitvoeren van het programma binnen een docker container.

## Opdracht

Een patiënt wordt ontslagen uit Ziekenhuis A en doorverwezen naar verpleeghuis B.  Bij deze verwijzing wordt er een verwijsbrief en informatie over de allergieën van de patiënt verstuurd naar verpleeghuis B.  Bij aankomst in verpleeghuis B vraagt het verpleeghuis om extra informatie over het medicatiegebruik van de patiënt.

**Vereiste:**

- .NET 5.0
- Validatie checks moeten uitgevoerd worden
- Er dient foutafhandeling te zijn.
- Het moet mogelijk zijn om documenten te wisselen via een REST API


## Design programma

Er is gekozen voor een multi-project solution met een ASP.NET 5.0 WEB API.
Binnen dit programma is het mogelijk om het volgende te doen:

- Een **HealthFacility** zoals een ziekenhuis of een verpleeghuis kan aangemaakt worden.
- Hier kunnen **Patients** aan toegewezen worden.
- Als een **HealthFacility** een patient heeft kan hieraan **PatientInformation** toegewezen worden zoals informatie over medicatie gebruik maar ook verwijsbrieven.
- Op het moment dat een patient doorverwezen moet worden kan deze een transfer krijgen naar nieuwe **HealthFacility**. Echter de informatie gaat niet automatisch mee. Hier moet **InformationOwnership** gegeven voor worden.
- Hier kan een **HealthFacility** om vragen door middel van een **InformationOwnershipRequest**, of een beherende **HealthFacility** kan **InformationOwnership** geven.

De project layout:

- **API**: Bevat alle endpoints voor de rest API en regelt hoofdzakelijk de validatie van inkomende informatie. Daarnaast ook nog het loggen.
- **Data**: Bevat de repositories en mock repositories voor toegang tot de mssql database.
- **Factory**: Om tijdens het testen makkelijk te kunnen wisselen tussen mock repositories en respositories is gebruik gemaakt van een abstract factory, deze is een afzonderlijke class library gezet.
- **Logic**: Bevat de logic voor de communicatie tussen de API en Data access layer.

## Toelichting

Voor dit programma is gekozen informatie te delen via information ownerships. Een HealthFaciltity verkrijgt ownership op 3 manieren:

- Informatie toevoegen aan het systeem voor een patient.
- Informatie toegang krijgen van een andere HealthFaciltity .
- Informatie vragen van een andere HealthFaciltity 

## Testcase 

Om de benodigde informatie te zien voor elke request / object kan de `[localhost]/swagger` pagina geraadpleegd worden.

**HealthFacility Ziekenhuis A en Verpleeghuis B moeten aangemaakt worden via de url**:

````
POST - [localhost]/facility/
````

**Patient A kan worden aangemaakt worden via de url:**

````
POST - [localhost]/patient/
````

**PatientInformatie zoals de verwijsbrief, informatie over medicatie gebruik en allergieën kan worden toegewezen aan de Ziekenhuis A en Patient A:**

````
POST - [localhost]/patientInformation/
````

**Patient A kan doorverwezen worden naar Verpleeghuis B via de url:**

````
POST - [localhost]/patient/transfer/
````

**Informatie toegang kan gegeven worden via de url:**

````
POST - [localhost]/patientinformation/transfer/
````

**Een verzoek voor overige informatie over het medicatiegebruik van patient A kan via de url:**

````
POST - [localhost]/patientinformation/request/
````

**Ziekenhuis A kan de het verzoek accepteren via de url:**

````
POST - [localhost]/patientinformation/accept/
````

