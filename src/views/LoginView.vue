<template>
  <div class='loginView'>
            <div class="box">
              <!-- <form> -->
                <div class="field">
                  <div class="control">
                    <input 
                    class="input is-large" 
                    type="email" 
                    placeholder="Почта" 
                    autofocus=""
                    v-model="email">
                  </div>
                </div>

                <div class="field">
                  <div class="control">
                    <input 
                    class="input is-large" 
                    type="password" 
                    placeholder="Пароль"
                    v-model="password">
                  </div>
                </div>
                <div class="button is-block is-primary is-large is-fullwidth" 
                @click="doLogin()">Войти</div>
              <!-- </form> -->
            </div>
  </div>
</template>

<script>
  import { mapActions } from 'vuex';
export default {
  data() {
    return {
      email: "test@mail.ru" , password: "pwd"
    }
  },
  components: {},
  computed: {},
  methods: {
    ...mapActions(['TRY_LOGIN']),
    doLogin: function  () {
      this.TRY_LOGIN(this)
    }
  },
  mounted() { }
}
</script>

<style lang='scss'>
  .loginView{display: flex; justify-content: center;}
.loginView .box{ width:  50%;}
</style>
