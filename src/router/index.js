import { createRouter, createWebHashHistory } from 'vue-router'
import HomeView from '@/views/HomeView.vue'
import LoginView from '@/views/LoginView.vue'
import ProfileView from '@/views/ProfileView.vue'
import RegisterView from '@/views/RegisterView.vue'
import AuctionView from '@/views/AuctionView.vue'
import CreateAuctionView from '@/views/CreateAuctionView.vue'
import { mapActions } from 'vuex';

const router = createRouter({
  history: createWebHashHistory(), // createWebHistory(), // createWebHistory(process.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView
    },
    {
      path: '/reg',
      name: 'reg',
      component: RegisterView
    },
    {
      path: '/profile',
      name: 'profile',
      component: ProfileView
    },
    {
      path: '/auction',
      name: 'auction',
      component: AuctionView
    },
    {
      path: '/auction/add',
      name: 'createAuction',
      component: CreateAuctionView
    },
    {
      path: '/logout',
      name: 'logout',
      component: {
        methods: {
          ...mapActions('users', ['logOut']),
        },
        mounted: function (){
          this.logOut();
          this.$router.push({ name: 'home' });
        },
      }
    }
  ]
})

export default router
