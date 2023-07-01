import Vue from 'vue'
import VueRouter from 'vue-router'

import App from './App.vue'
import routes from './router.js'

Vue.config.productionTip = false

Vue.use(VueRouter);

const router = new VueRouter({
  routes // raccourci pour `routes: routes`
})

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
