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

function createData(title: string, year: number, rating: number) {
    return { title, year, rating }
}

const rows = [
    createData("Settlers of Catan", 1997, 6.5),
    createData("Carcasonne", 2001, 7.2),
    createData("Splendor", 2014, 7.4)
]

const Games = () => {
    const classes = useStyles();

    return (
        <TableContainer component={Paper}>
            <Table className={classes.table} aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell>Title</TableCell>
                        <TableCell align="right">Year</TableCell>
                        <TableCell align="right">BGG Rating</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {rows.map((row) => (
                        <TableRow>
                            <TableCell>{row.title}</TableCell>
                            <TableCell align="right">{row.year}</TableCell>
                            <TableCell align="right">{row.rating}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    )
};

export default Games;