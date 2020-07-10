// import api from "./ApisServer";
import axios from 'axios';
export default {
    getALL() {
        return axios.get('https://localhost:44348/api/sanpham');
    },
    get(id) {
        return axios.get('https://localhost:44348/api/sanpham/' + id);
    },
    SuaSP(id, sp) {
        return axios.put('https://localhost:44348/api/sanpham/' + id, sp)
    },
    ThemSP(sp) {
        return axios.post('https://localhost:44348/api/sanpham',sp);
    },
    timKiemSP(id) {
        return axios.get('https://localhost:44348/api/TimKiemSP/' + id);
    },
    delete(id) {
        return axios.delete("https://localhost:44348/api/sanpham/" + id);
    },
    getAllLoaiSP() {
        return axios.get('https://localhost:44348/api/LoaiSP');
    },
    getAllNhaCC() {
        return axios.get('https://localhost:44348/api/NhaCC');
    }
}