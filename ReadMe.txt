MSSV: 1760327 
Ten: Tran Tuan Huy
Lop: 17CKCL
Nhom: 1 nguoi

Cac chuc nang chinh:
1.Chon 1 thu muc them vao danh sach cac tap tin cua thu muc duoc chon (khi chon thu muc moi se xoa di cac tap tin cu)

2.Chon 1 thu muc them vao danh sach cac thuc muc con cua thu muc duoc chon (khi chon thu muc moi se xoa di cac thuc muc con cu)

3.Hien thi danh sach cac hanh dong co the co de nguoi dung lua chon them vao danh sach

- Cac kieu hanh dong dua vao mot menu, nguoi dung bam vao menu se hien ra cac hanh dong de lua chon (bam vao menu item se tu dong them vao danh sach hanh dong ben duoi)
 
- Co 5 hanh dong:
	+Replace : thay the , nguoi dung nhap vao 2 tham so chuoi can thay the va chuoi thay the 
(
khong cho nguoi dung bo trong hoac nhap cac ki tu '/', '\' , ':', '*' ,'?' ,'"' ,'<' ,'>' ,'|'
neu nhap sai hien ra thong bao va tra ve trang thai cu
khong cho chuyen trang thai neu tham so sai
)

	+New case : thay doi keu chu , nguoi dung chon kieu chu moi
(nguoi dung chon kieu chu tren 3 radio button "1.Upper Case", "2.Lower Case", "3.Proper Case")

	+Fullname normalize : chuan hoa ho ten , khong co tham so

	+Move : thay doi vi tri, nguoi dung nhap vao 3 tham so vi tri can di chuyen, do dai chuoi can di chuyen, chon vi tri di chuyen
(
khong cho nguoi dung nhap cac ki tu khong phai la so
neu nhap sai hien ra thong bao va tra ve trang thai cu
khong cho chuyen trang thai neu tham so sai
)

	+Unique name: dat ten duy nhat , khong co tham so

- Cac hanh dong duoc hien thi tren mot list box, moi hanh dong tren listbox se co mot expander de xem chi tiet, ten hanh dong, check box de active hay unactive hanh dong, va mot nut xoa hanh dong


- Cau hinh hanh dong bang cach chuot phai vao hanh dong trong list box va chon edit

4.Bam start batch se lan luot ap cac hanh dong va doi ten
  Cho phep xem truoc : Hoan thanh
  Canh bao ten trung : Hoan thanh (ten moi trung khi co nhieu ten moi giong nhau, ten moi da ton tai trong thu muc)	

5.Tap hanh dong luu lai duoi dang preset (bang mot nut save) va co the duoc doc len (bang mot nut open) cho nguoi dung lua chon cac hanh dong (trong mot combobox)
format pre set:

<ItemMethod>

trang thai cua hanh dong (active hay khong active)
<Action>

ten hanh dong
<Args>

tham so hanh dong


<\>
 