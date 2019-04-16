DROP SCHEMA IF EXISTS login_reg_demo;
CREATE SCHEMA login_reg_demo;
USE login_reg_demo;

-- CREATE TABLE users (
--   user_id       INTEGER       NOT NULL  AUTO_INCREMENT  PRIMARY KEY,
--   first_name    VARCHAR(255)  NOT NULL,
--   last_name     VARCHAR(255)  NOT NULL,
--   email         VARCHAR(255)  NOT NULL,
--   password      VARCHAR(255)  NOT NULL,
--   user_created  TIMESTAMP     NOT NULL  DEFAULT NOW(),
--   user_updated  TIMESTAMP     NOT NULL  DEFAULT NOW()   ON UPDATE NOW(),
-- );