<template>
  <div class='loginView'>
            <div class="box is-fullheight">
              <!-- <form> -->

                <div class="field" v-if="this.errors == true">
                  <article class="message is-danger">
                    <div class="message-header">
                      <p>Ошибка: Неверный логин или пароль</p>
                      <button class="delete" aria-label="delete" 
                      v-on:click="this.errors = false"></button>
                    </div>
                  </article>
                </div>

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
      email: "" , password: "",
      errors: false
    }
  },
  components: {},
  computed: {},
  methods: {
    ...mapActions('users',['userAuth']),
    doLogin: function  () {
      this.errors = false;

      this.userAuth(this).then((result)=>{
        if(result != true){
          this.errors = true;
          return;
        }

        this.$router.push({ name: 'home' })

      });
    }
  },
  mounted() { }
}
</script>

<style lang='scss'>
.loginView {
  display: flex;
  justify-content: center;
  min-height: 64vh;
}

.loginView .box {
  width: 50%;
  height: 100%;
}
</style>
