BEGIN;

ALTER TABLE users add scopeID char(36) not null default '00000000-0000-0000-0000-000000000000';

COMMIT;
