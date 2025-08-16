CREATE TABLE MotelAmenities (
    Id BIGINT IDENTITY PRIMARY KEY,
    MotelId BIGINT NOT NULL,
    AmenityId BIGINT NOT NULL,
    AmenityOptionId BIGINT NOT NULL,
    Note NVARCHAR(MAX),
    CreatedAt DATETIME2 NOT NULL,
    UpdatedAt DATETIME2 NOT NULL,

    CONSTRAINT FK_MotelAmenities_Motels FOREIGN KEY (MotelId) REFERENCES Motels(Id),
    CONSTRAINT FK_MotelAmenities_Amenities FOREIGN KEY (AmenityId) REFERENCES Amenities(Id),
    CONSTRAINT FK_MotelAmenities_AmenityOptions FOREIGN KEY (AmenityOptionId) REFERENCES AmenityOptions(Id)
);

