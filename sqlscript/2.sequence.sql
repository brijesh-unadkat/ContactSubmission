-- SEQUENCE: ContactManagement.Contact_Id_seq

-- DROP SEQUENCE IF EXISTS "ContactManagement"."Contact_Id_seq";

CREATE SEQUENCE IF NOT EXISTS "ContactManagement"."Contact_Id_seq"
    INCREMENT 1
    START 0
    MINVALUE 0
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE "ContactManagement"."Contact_Id_seq"
    OWNER TO postgres;