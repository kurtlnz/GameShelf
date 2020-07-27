import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import {
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Paper
} from '@material-ui/core';

const useStyles = makeStyles({
    table: {
        minWidth: 1000,
    },
});

function createData(firstName: string, lastName: string, emailAddress: string, dateOfBirth: string) {
    return { firstName, lastName, emailAddress, dateOfBirth }
}

const rows = [
    createData("Kurt", "Lim", "klim049@gmail.com", "31/03/1989"),
    createData("John", "Dog", "jdogg@gmail.com", "01/04/1994"),
    createData("Shaz", "Cuzzina", "shazzacuzza@yahoo.com", "05/05/1970")
]

const Users = () => {
    const classes = useStyles();

    return (
        <TableContainer component={Paper}>
            <Table className={classes.table} aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell>First Name</TableCell>
                        <TableCell>Last Name</TableCell>
                        <TableCell>Email Address</TableCell>
                        <TableCell>Date of Birth</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {rows.map((row) => (
                        <TableRow>
                            <TableCell>{row.firstName}</TableCell>
                            <TableCell>{row.lastName}</TableCell>
                            <TableCell>{row.emailAddress}</TableCell>
                            <TableCell>{row.dateOfBirth}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    )
}

export default Users;