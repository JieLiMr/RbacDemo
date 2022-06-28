import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import ElementUI from 'element-ui';
import axios from 'axios';
import 'element-ui/lib/theme-chalk/index.css';
import VueCookies from 'vue-cookies'
Vue.use(VueCookies);
Vue.use(ElementUI);
axios.defaults.withCredentials = true;
axios.defaults.baseURL = 'http://localhost:33437';
axios.defaults.headers.common['Authorization'] = `bearer ${VueCookies.get('Taken')}` ;
Vue.prototype.$axios=axios;
Vue.config.productionTip = false




new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
