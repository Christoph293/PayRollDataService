CREATE TABLE [BusinessAssociate] (
  [ID] <type>,
  [Name] <type>
);

CREATE TABLE [Location] (
  [ID] <type>,
  [Name] <type>,
  [BusinessAssociateFKID] <type>,
  CONSTRAINT [FK_Location.BusinessAssociateFKID]
    FOREIGN KEY ([BusinessAssociateFKID])
      REFERENCES [BusinessAssociate]([ID])
);

CREATE TABLE [Employee] (
  [ID] <type>,
  [Name] <type>,
  [BusinessAssociateID] <type>,
  CONSTRAINT [FK_Employee.BusinessAssociateID]
    FOREIGN KEY ([BusinessAssociateID])
      REFERENCES [BusinessAssociate]([ID])
);

CREATE TABLE [EmployeeLocationMap] (
  [ID] <type>,
  [EmployeeID] <type>,
  [LocationID] <type>,
  CONSTRAINT [FK_EmployeeLocationMap.EmployeeID]
    FOREIGN KEY ([EmployeeID])
      REFERENCES [Employee]([ID]),
  CONSTRAINT [FK_EmployeeLocationMap.LocationID]
    FOREIGN KEY ([LocationID])
      REFERENCES [Location]([ID])
);

CREATE TABLE [Adressdata] (
  [ID] <type>,
  [Street] <type>,
  [StreetNo] <type>,
  [PostalCode] <type>,
  [City] <type>,
  [Country] <type>
);

CREATE TABLE [Communication] (
  [ID] <type>,
  [Type] <type>,
  [Content] <type>
);

CREATE TABLE [CommunicationMap] (
  [ID] <type>,
  [EmployeeID] <type>,
  [LocationID] <type>,
  [BusinessAssociateID] <type>,
  [CommunicationID] <type>,
  CONSTRAINT [FK_CommunicationMap.LocationID]
    FOREIGN KEY ([LocationID])
      REFERENCES [Location]([ID]),
  CONSTRAINT [FK_CommunicationMap.BusinessAssociateID]
    FOREIGN KEY ([BusinessAssociateID])
      REFERENCES [BusinessAssociate]([ID]),
  CONSTRAINT [FK_CommunicationMap.CommunicationID]
    FOREIGN KEY ([CommunicationID])
      REFERENCES [Communication]([ID]),
  CONSTRAINT [FK_CommunicationMap.EmployeeID]
    FOREIGN KEY ([EmployeeID])
      REFERENCES [Employee]([ID])
);

CREATE TABLE [AdressDataMap] (
  [ID] <type>,
  [EmployeeID] <type>,
  [LocationID] <type>,
  [BusinessAssociateID] <type>,
  [AdressDataID] <type>,
  CONSTRAINT [FK_AdressDataMap.LocationID]
    FOREIGN KEY ([LocationID])
      REFERENCES [Location]([ID]),
  CONSTRAINT [FK_AdressDataMap.BusinessAssociateID]
    FOREIGN KEY ([BusinessAssociateID])
      REFERENCES [BusinessAssociate]([ID]),
  CONSTRAINT [FK_AdressDataMap.AdressDataID]
    FOREIGN KEY ([AdressDataID])
      REFERENCES [Adressdata]([ID]),
  CONSTRAINT [FK_AdressDataMap.EmployeeID]
    FOREIGN KEY ([EmployeeID])
      REFERENCES [Employee]([ID])
);

