import Vue from "vue";
import Router from "vue-router";
Vue.use(Router);

import TestVue from './components/TestVue.vue';
import baitap1 from './components/baitap1.vue';
import ModalSanPham from './components/ModalSanPham.vue';
import ControlBar from './components/ControlBar.vue';
export default new Router({
    routes: [{
            path: '/',
            component: baitap1,
        },
        {
            path: '/testvue',
            component: TestVue,
        },
        {
            path: '/ModalSanPham',
            component: ModalSanPham,
        },
        {
            path: '/ControlBar',
            component: ControlBar,
        },

    ]
})