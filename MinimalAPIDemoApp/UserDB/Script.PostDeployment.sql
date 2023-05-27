if not exists (select 1 from dbo.[Student])
begin
	insert into dbo.[Student](Name, FamilyName, Address, Contact)
	values ('Rahul', 'Kumar', '123, Villash Road, Jagatpura, Jaipur, 341256', 8948098326),
	('Raju', 'Rastogi', '211, Rajmargh Road, Jagatpura, Jaipur, 341256', 8948098326),
	('Rajan', 'Bakolia', '287, Aligarh University, Jagatpura, 341256', 8948098326),
	('Brijesh', 'Pawar', '287, Aligarh University, Jagatpura, 341256', 8948098326),
	('Preeti', 'Tanwar', '346, JLN Marg, Jagatpura, 341256', 8948098326),
	('Gurmeet', 'Singh', '536, Alligarh University, Jagatpura, 341256', 8948098326),
	('Asif', 'Khan', '536,  Narayanpuri, Jagatpura, 341256', 8948098326),
	('Gaurav', 'Kapoor', '456, Nalanda Apartments, Jagatpura, Jaipur', 7894839743),
	('Prerna', 'Sinha', '875, Ganganagar, Patappuri, Jaipur', 4762837236);
end