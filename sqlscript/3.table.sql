-- Table: ContactManagement.Contact

-- DROP TABLE IF EXISTS "ContactManagement"."Contact";

CREATE TABLE IF NOT EXISTS "ContactManagement"."Contact"
(
    "Id" bigint NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 0 MINVALUE 0 MAXVALUE 9223372036854775807 CACHE 1 ),
    "Name" character varying COLLATE pg_catalog."default",
    "PhoneNumber" character varying COLLATE pg_catalog."default",
    "EmailAddress" character varying COLLATE pg_catalog."default",
    CONSTRAINT "Contact_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS "ContactManagement"."Contact"
    OWNER to postgres;