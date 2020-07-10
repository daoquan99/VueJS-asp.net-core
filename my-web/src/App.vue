<template>
  <v-app>
    <template>
      <v-card class="mx-auto overflow-hidden" height="100%" width="100%" style="border-radius: 0;margin:0;">
        <v-app-bar color="deep-purple" dark >
          <v-app-bar-nav-icon @click="drawer = true" ></v-app-bar-nav-icon>
          <v-toolbar-title>Phần mềm quản lý bán hàng</v-toolbar-title>
        </v-app-bar>
        <v-navigation-drawer v-model="drawer" absolute temporary >
          <v-list nav  dense >
            <v-list-item-group active-class="deep-purple--text text--accent-4" >
              <router-link to="/" style="text-decoration:none;">
                <v-list-item>
                    <v-list-item-icon>
                      <v-icon>mdi-home</v-icon>
                    </v-list-item-icon>
                    <v-list-item-title>Home</v-list-item-title>
                </v-list-item>
              </router-link>

              <router-link to="/ModalSanPham" style="text-decoration:none;">
                <v-list-item>
                    <v-list-item-icon>
                      <v-icon>mdi-account</v-icon>
                    </v-list-item-icon>
                    <v-list-item-title>Sản phẩm</v-list-item-title>
                </v-list-item>
              </router-link>

              <router-link to="/TestVue" style="text-decoration:none;">
                <v-list-item>
                  <v-list-item-icon>
                    <v-icon>mdi-account</v-icon>
                  </v-list-item-icon>
                  <v-list-item-title>test vue</v-list-item-title>
                </v-list-item>
              </router-link>

            </v-list-item-group>
          </v-list>
        </v-navigation-drawer>
        <v-content>
          <transition name="fade">
            <router-view></router-view>
          </transition>
        </v-content>
      </v-card>
    </template>
  </v-app>
</template>
<script>
import ModalSanPham from './components/ModalSanPham.vue';
import TestVue from './components/TestVue.vue';

export default {
  components:[
    { ModalSanPham }, { TestVue }
  ],
  data() {
    return {
      drawer:false,
    }
  },
};
</script>

<style>
  .v-toolbar__title {
    text-transform: uppercase;
}
</style>