<template>
    <table class="table table-striped table-hover">
        <thead>
        <tr>
            <th scope="col">#</th>
            <th scope="col">Name</th>
            <th scope="col">Organisation</th>
            <th class="text-center">
                <div class="icon icon-add" data-remodal-target="createModal"/>
            </th>
        </tr>
        </thead>
        <tbody v-if="persons.length !== 0">
        <tr class="mdc-data-table__row" v-for="person in persons" :key="person.id">
            <td>{{ person.id }}</td>
            <td class="mdc-data-table__cell">{{ person.name }}</td>
            <td class="mdc-data-table__cell">
            <span v-for="org in person.organizations" :key="org.id">
              {{ org }} |
            </span>
            </td>
            <td class="control-panel">
                <button class="icon icon-edit" data-remodal-target="editModal" v-on:click="selectPerson(person.id)"/>
                <button class="icon icon-remove" v-on:click="removePerson(person.id)"/>
            </td>
        </tr>
        </tbody>
        <tbody v-else>
        <Spinner/>
        </tbody>
    </table>
    <CreateModal @onCreatePerson="onUpdate"/>
    <EditModal :selectedPersonEditingData="selectedPersonEditingData" @onEditPerson="onUpdate"/>
</template>

<script>
    import axios from "axios";
    import CreateModal from "./modal/CreateModal";
    import EditModal from "./modal/EditModal";
    import Spinner from "../Spinner";

    export default {
        name: 'Table',
        components: {Spinner, EditModal, CreateModal},
        data() {
            return {
                persons: [],
                personName: '',
                personOrg: [],
                selectedPersonEditingData: {}
            };
        },
        methods: {
            selectPerson: function (id) {
                console.log(`editHandler(${id})`);
                axios.get(`http://localhost:5000/person/${id}`)
                    .then(res => {
                        localStorage.setItem('selectedPerson', JSON.stringify(res.data))
                        this.selectedPersonEditingData = res.data;
                        this.personName = res.data.title;
                        console.log(res.data)
                    })
            },
            fetchPersons: function () {
                console.log('fetchPersons()')
                axios.get('http://localhost:5000/person')
                    .then(res => {
                        console.log(res.data)
                        this.persons = res.data
                    })
            },
            removePerson: function (id) {
                console.log(`removeHandler(${id})`);
                axios.delete(`http://localhost:5000/person/${id}`)
                    .then(res => {
                        let isRemove = confirm("Вы действительно хотите удалить выделенного персонажа?");
                        if (isRemove) {
                            console.log(res.data)
                        } else {
                            console.log('Отказ!')
                        }
                    })
                    .then(() => {
                        this.fetchPersons()
                    })
            },
            onUpdate(data) {
                console.log("onUpdate()")
                this.personName = data;
                this.personOrg = data
                this.fetchPersons()
            }
        },
        mounted: function () {
            this.fetchPersons()
        },
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style src="./Persons.css" scoped></style>