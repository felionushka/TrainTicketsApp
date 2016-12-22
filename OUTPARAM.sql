CREATE PROCEDURE "OUTPARAM" (
  "OUTP" OUT VARCHAR2) IS

BEGIN  -- Return a scalar output parameter

  outp:= 'Successfully returned output parameter!';

END;
