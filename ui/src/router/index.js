import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView,
    children:[
      {
        path: '/MenuAdd',
        name: '/MenuAdd',
        component: () => import('../views/AddView.vue')
      }
    ]
  },
  {
    path: '/about',
    name: 'about',
    component: () => import('../views/AboutView.vue')
  },
  {
    path: '/ShowView',
    name: 'ShowView',
    component: () => import('../views/ShowView.vue')
  },
  {
    path: '/MenuView',
    name: 'MenuView',
    component: () => import('../views/MenuView.vue')
  }
  ,
 
  
]

const router = new VueRouter({
  routes
})

export default router
