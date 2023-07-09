Model Sınıfları:

Dokuman: Dokümanların temsil edildiği sınıftır. Her bir dokümanın başlık, alt başlık, içerik, kategori ve oluşturma tarihi gibi özellikleri bulunur.
dokumanid, title, subtitle, content, created_at, categoryid
Category: Dokümanların kategorize edildiği sınıftır. Her bir kategori adını içerir ve birçok dokümana ait olabilir.
categoryid, name
Role: Role bilgilerinin temsil edildiği sınıftır.
roleid, rolename, userroles
User: Kullanıcı bilgilerinin temsil edildiği sınıftır.
userid, username, password, name, surname, email
UserRoles: Kullanıcı rollerinin temsil edildiği sınıftır. Many to Many bağlantı vardır(USER manytomany ROLE). Gerekli yapılandırmalar yapılmıştır.

Service Sınıfları:

DokumanService: Dokümanların veritabanı işlemlerini gerçekleştiren sınıftır. Dokümanların oluşturulması, güncellenmesi, silinmesi ve listelenmesi gibi işlemleri sağlar.
CategoryService: Kategorilerin veritabanı işlemlerini gerçekleştiren sınıftır. Kategori oluşturma, güncelleme, silme ve listeleme gibi işlemleri sağlar.
RoleService: Rollerin veritabanı işlemlerini gerçekleştiren sınıftır. Rollerin oluşturulması, güncellenmesi, silinmesi ve listelenmesi gibi işlemleri sağlar.
UserService: Kullanıcıların veritabanı işlemlerini gerçekleştiren sınıftır. Dokümanların oluşturulması, güncellenmesi, silinmesi ve listelenmesi gibi işlemleri sağlar.
ayrıca şifrelerin hashlenmesi, girilen şifrenin doğruluğu gibi kontroller de yapılır. 

Veritabanı İşlemleri:

ApplicationDbContext: Entity Framework kullanılarak oluşturulan veritabanı bağlantısını temsil eder. Dokümanlar ve kategoriler gibi varlık sınıflarının DbSet'lerini içerir.
İş Mantığı:

Proje, kullanıcılara dokümanlar oluşturma, kategori oluşturma, dokümanları kategorilere atama, dokümanları güncelleme ve silme gibi işlemleri yapma imkanı sunar.
Dokümanlar ve kategoriler arasındaki ilişki, bir dokümanın bir kategoriye ait olabilmesi ve bir kategorinin birden çok dokümana ait olabilmesi şeklinde yapılandırılmıştır.

Kullanıcılar, projeyi kullanarak dokümanları kolayca yönetebilir ve istedikleri kategorilere dokümanları atayabilir.
Kullanıcılar birden fazla role sahip olabilir ve bir rol birden fazla kullanıcıda bulunabilir.

Bu proje, doküman yönetimi için basit ve kullanıcı dostu bir arayüz sunan bir uygulamadır. Dokümanların etkin yönetimi için gerekli işlemleri gerçekleştirir ve verileri MYSQL veritabanında saklar. .net 7, Entity framework 7, Mysql 8 jquery, bootstrap kullanılmıştır.

Login ekranında LoginController çalışmaktadır ve Session a kullanıcı adı username kaydedilmektedir. 
uygulama önyüz frontend ve backend database service katmanı olmak üzere 2 katmandan oluşmaktadır

EN:
Model Classes:

Document: It is the class in which the documents are represented. Each document has features such as title, subtitle, content, category and date of creation.
documentid, title, subtitle, content, created_at, categoryid
Category: It is the class in which the documents are categorized. Each category contains its name and can belong to many documents.
categoryid, name
Role: It is the class in which the role information is represented.
roleid, rolename, userroles
User: It is the class where user information is represented.
userid, username, password, name, surname, email
UserRoles: It is the class in which user roles are represented. There are Many to Many connections (USER manytomany ROLE). Necessary configurations have been made.

Service Classes:

DokumanService: It is the class that performs database operations of documents. It provides operations such as creating, updating, deleting and listing documents.
CategoryService: It is the class that performs database operations of categories. It provides operations such as creating, updating, deleting and listing categories.
RoleService: It is the class that performs database operations of roles. It provides operations such as creating, updating, deleting and listing roles.
UserService: It is the class that handles the database operations of the users. It provides operations such as creating, updating, deleting and listing documents.
In addition, checks such as hashing passwords and correctness of the entered password are also carried out.

Database Operations:

ApplicationDbContext: Represents the database connection created using Entity Framework. It contains DbSets of entity classes such as documents and categories.
Business Logic:

The project allows users to create documents, create categories, assign documents to categories, update and delete documents.
The relationship between documents and categories is structured so that a document can belong to a category and a category can belong to more than one document.

Users can easily manage documents using the project and assign documents to the categories they want.
Users can have multiple roles, and a role can reside with more than one user.

This project is an application that offers a simple and user-friendly interface for document management. It performs the necessary operations for the effective management of documents and stores the data in the MYSQL database. .net 7, Entity framework 7, Mysql 8 jquery, bootstrap are used.

LoginController is running on the login screen and username username is saved to Session.
The application consists of 2 layers: frontend frontend and backend database service layer.