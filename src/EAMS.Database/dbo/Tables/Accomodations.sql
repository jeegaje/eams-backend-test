CREATE TABLE Accomodations (
    Id BIGINT IDENTITY PRIMARY KEY,
    Name NVARCHAR(255),
    Region NVARCHAR(255),
    Street NVARCHAR(255),
    Suburb NVARCHAR(255),
    Postcode INT,
    Density NVARCHAR(255),
    Phone NVARCHAR(255),
    Email NVARCHAR(255),
    CreatedAt DATETIME2 NOT NULL,
    UpdatedAt DATETIME2 NOT NULL,
    MotelType NVARCHAR(255),
    State NVARCHAR(255) DEFAULT 'VIC',
    Duration NVARCHAR(MAX), -- Consider splitting if structured
    Website NVARCHAR(255),
    Inactive BIT
);