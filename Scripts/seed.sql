use qudoos_talentconnect
Go

if not exists (select * from webpages_roles where RoleName  = 'Admin')
begin
	insert into webpages_roles (RoleName)
	select 'Admin' union
	select 'User'
end
else
	print 'roles already created'