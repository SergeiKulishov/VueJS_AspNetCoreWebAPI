<template>
    <div class="remodal" data-remodal-id="createModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Create Person</h5>
                    <button type="button" class="remodal-close" data-remodal-action="close" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3 row">
                        <label for="name" class="col-sm-2 col-form-label">Name</label>
                        <div class="col-sm-10">
                            <input type="text" v-model="personName" class="form-control" id="name">
                        </div>
                    </div>
                    <div class="d-grid">
                        <label class="col-sm-2 col-form-label">Organization</label>
                        <div>
                            <Multiselect @createPerson="onUpdate"/>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-remodal-action="confirm" v-on:click="createPerson" class="remodal-confirm">Save
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import Multiselect from "@/components/Multiselect";
    import axios from "axios";

    export default {
        name: "CreateModal",
        components: {
            Multiselect
        },
        data() {
            return {
                personName: 'Tolik',
                personOrg: ['Google', 'Tesla'],
            };
        },
        methods: {
            createPerson: function () {
                console.log("createPerson()")
                console.log(this.personName)
                console.log(this.personOrg)
                axios.post(`http://localhost:5000/person`, {
                    name: 'Tolik',
                    organizations: ['Google', 'Tesla']
                })
                    .then(res => {
                        console.log(res.data)
                        this.personName = ''
                        this.personOrg = []
                    })
            },
            onUpdate(data) {
                console.log('onUpdate()')
                this.personOrg = data;
            }
        }
    }
</script>

<style scoped>

</style>