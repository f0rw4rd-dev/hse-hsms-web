import psycopg2

DB_HOST = 'localhost'
DB_NAME = 'hardware_store_ms'
DB_USER = 'postgres'
DB_PASSWORD = 'root'
DB_PORT = 5433

conn = psycopg2.connect(host=DB_HOST, port=DB_PORT, database=DB_NAME, user=DB_USER, password=DB_PASSWORD)

tables = ('OrderComponents', 'Orders', 'Supplies', 'Configurations', 'ComponentDetails', 'ComponentStorages', 'Components', 'ComponentTypes', 'DetailTypes', 'Warehouses', 'Suppliers', 'Users')

choice = int(input('0 - drop, 1 - insert: '))

with conn.cursor() as cur, open('data.sql', encoding='utf8') as f:
    if choice == 0:
        for table in tables:
            cur.execute(f'DROP TABLE "{table}"')
    elif choice == 1:
        for line in f.readlines():
            if len(line.strip()) > 0:
                cur.execute(line)

conn.commit()

input('Done. Press any key to exit...')
