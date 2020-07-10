<template>
  <v-card>
    <v-alert max-height="75" style="border-radius: 0;margin:0;">
      <div style="text-align:center;font-size:30px">
        <span>Danh sách sản phẩm</span>
      </div>
    </v-alert>
    <v-container>
      <div class="row" style="margin:0 0 0 20px;">
        <v-col cols="12" md="4">
          <v-text-field v-model="search" @input="TimKiem" label="Tìm kiếm sản phẩm" required></v-text-field>
        </v-col>
        <v-col cols="12" md="6">
          <div class="float-right">
            <v-btn
              class="my-2"
              depressed
              outlined
              large
              dark
              color="#1CA94F"
              title="Thêm sản phẩm"
              @click="createSP()"
            >Create</v-btn>
          </div>
        </v-col>
      </div>
      <v-data-table :headers="headers" :items="contacts" :items-per-page="5" class="elevation-1">
        <template v-slot:item.ThaoTac="{item}">
          <v-btn icon small class="md-0">
            <v-icon small color="teal" @click="SuaSP(item)">edit</v-icon>
          </v-btn>
          <v-btn icon small class="md-0">
            <v-icon small color="red" @click="XoaSP(item)">delete</v-icon>
          </v-btn>
        </template>
      </v-data-table>
    </v-container>

    <v-dialog v-model="dialogXoaSanPham" persistent max-width="290">
      <v-card>
        <v-card-title class="headline">Xác nhận xóa</v-card-title>
        <v-card-text>Bạn có chắc chắn muốn xóa bản ghi nãy không?</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="green darken-1" text @click="dialogXoaSanPham = false">Hủy</v-btn>
          <v-btn color="green darken-1" text @click="xacNhanXoa()">Đồng ý</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <v-dialog v-model="dialogSuaSanPham" persistent max-width="540px">
      <v-card>
        <v-card-title>
          <span
            class="headline text-center"
          >{{ kiemtra === true ? 'Cập nhật thông tin sản phẩm':'Thêm sản phẩm'}}</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-form>
              <v-row>
                <v-col cols="12" sm="6">
                  <v-text-field
                    v-model="sanphamSeleted.tenSP"
                    :counter="50"
                    label="Tên sản phẩm"
                    required
                  ></v-text-field>
                </v-col>
                <v-col cols="12" sm="6">
                  <v-text-field v-model="sanphamSeleted.donGia" label="Đơn giá" required></v-text-field>
                </v-col>
              </v-row>

              <v-row>
                <v-col cols="12" sm="6">
                  <v-text-field v-model="sanphamSeleted.soLuong" label="Số lượng"></v-text-field>
                </v-col>
                <v-col cols="12" sm="6">
                  <v-textarea v-model="sanphamSeleted.moTa" label="Mô tả" rows="1"></v-textarea>
                </v-col>
              </v-row>
              <v-row>
                <v-col cols="12" sm="6">
                  <v-autocomplete
                    v-model="sanphamSeleted.maLoaiSP"
                    :items="lstLoaiSP"
                    item-text="tenLoai"
                    item-value="maLoaiSP"
                    dense
                    label="Loại sản phẩm"
                  ></v-autocomplete>
                </v-col>
                <v-col cols="12" sm="6">
                  <v-autocomplete
                    v-model="sanphamSeleted.maNCC"
                    :items="lstNCC"
                    item-text="tenNCC"
                    item-value="maNCC"
                    dense
                    label="Nhà cung cấp"
                  ></v-autocomplete>
                </v-col>
              </v-row>
            </v-form>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="dialogSuaSanPham = false">Hủy</v-btn>
          <v-btn
            color="blue darken-1"
            text
            @click="XacNhanSua()"
            type="submit"
          >{{ kiemtra === true ? 'Cập nhật':'Thêm mới'}}</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-card>
</template>

<script>
import ContactApi from "../ContactApi";
export default {
  data() {
    return {
      dialogXoaSanPham: false,
      dialogSuaSanPham: false,
      kiemtra: false,
      headers: [
        {
          text: "Tên sản phẩm",
          align: "center",
          value: "tenSP"
        },
        { text: "Số lượng", value: "soLuong", align: "center" },
        { text: "Đơn giá", value: "donGia", align: "center" },
        { text: "Mô tả", value: "moTa", align: "center" },
        { text: "Mã NCC", value: "nhaCC.tenNCC", align: "center" },
        { text: "Mã loại SP", value: "loaiSP.tenLoai", align: "center" },
        { text: "Thao tác", value: "ThaoTac", align: "center" }
      ],
      contacts: [],
      sanphamSeleted: {},
      search: "",
      lstNCC: [],
      lstLoaiSP: []
    };
  },
  created() {
    ContactApi.getALL().then(response => {
      this.contacts = response.data;
    });
    ContactApi.getAllLoaiSP().then(response => {
      this.lstLoaiSP = response.data;
    });
    ContactApi.getAllNhaCC().then(response => {
      this.lstNCC = response.data;
    });
  },
  methods: {
    XoaSP(item) {
      this.dialogXoaSanPham = true;
      this.sanphamSeleted = item;
    },
    SuaSP(item) {
      this.kiemtra = true;
      this.dialogSuaSanPham = true;
      this.sanphamSeleted = item;
    },
    createSP() {
      this.kiemtra = false;
      this.dialogSuaSanPham = true;
    },
    getData() {
      ContactApi.getALL().then(response => {
        this.contacts = response.data;
      });
    },
    xacNhanXoa() {
      ContactApi.delete(this.sanphamSeleted.maSP).then(response => {
        console.log(response);
        this.getData();
        this.dialogXoaSanPham = false;
      });
    },
    XacNhanSua() {
      if (this.kiemtra === true) {
        this.sanphamSeleted.soLuong = parseInt(this.sanphamSeleted.soLuong);
        this.sanphamSeleted.donGia = parseInt(this.sanphamSeleted.donGia);
        ContactApi.SuaSP(this.sanphamSeleted.maSP, this.sanphamSeleted).then(
          response => {
            console.log(response);
            this.getData();
            this.dialogSuaSanPham = false;
          }
        );
      } 
      else {
        this.sanphamSeleted.soLuong = parseInt(this.sanphamSeleted.soLuong);
        this.sanphamSeleted.donGia = parseInt(this.sanphamSeleted.donGia);
        ContactApi.ThemSP(this.sanphamSeleted)
        .then(response => {
          console.log(response);
          this.getData();
          this.dialogSuaSanPham = false;
        })
        .catch(error => {
          console.log(error);
        }) 
      }
    },
    TimKiem() {
      if (this.search.length != 0) {
        ContactApi.timKiemSP(this.search).then(response => {
          this.contacts = response.data;
        });
      } else {
        this.getData();
      }
    }
  }
};
</script>

<style>
.v-data-table-header-mobile__wrapper {
    display: none;
}
</style>