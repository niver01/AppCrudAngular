import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ITaxpayer } from './../../models/ITaxpayer';
import { ApiTaxpayerService } from './../../service/api-taxpayer.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DialogTaxpayerComponent } from './dialog/dialog-taxpayer.component';
import { DialogDeleteComponent } from './../../common/dialog-delete/dialog-delete.component';

@Component({
  selector: 'app-taxpayer',
  templateUrl: './taxpayer.component.html',
  styleUrls: ['./taxpayer.component.scss'],
})
export class TaxpayerComponent implements OnInit {
  @ViewChild(MatPaginator) private _paginator: MatPaginator;
  @ViewChild(MatSort) private _sort: MatSort;
  public dataSource: MatTableDataSource<ITaxpayer>;
  public displayedColumns: string[] = ['IdContribuyente', 'Nombre', 'Action'];

  private _dialogWidth: string = '24em';
  private _duration: number = 5000;

  constructor(
    private _apiTaxpayerService: ApiTaxpayerService,
    private _dialog: MatDialog,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.getTaxpayer();
  }

  getTaxpayer(): void {
    this._apiTaxpayerService.get().subscribe(
      (res) => {
        if (res.result) {
          this.dataSource = new MatTableDataSource(res.data);
          this.dataSource.paginator = this._paginator;
          this.dataSource.sort = this._sort;
        }
      },
      (err) => {
        this._snackBar.open('Ocurrio un error al obtener los datos.', '', {
          duration: this._duration,
        });
        console.error(err);
      }
    );
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue?.trim().toLowerCase() ?? '';

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openAdd(): void {
    this.open();
  }

  openUpdate(element: ITaxpayer): void {
    this.open(element);
  }

  private open(element: ITaxpayer = null) {
    let dialogRef: MatDialogRef<DialogTaxpayerComponent>;

    dialogRef = this._dialog.open(DialogTaxpayerComponent, {
      data: element,
      width: this._dialogWidth,
    });

    dialogRef.afterClosed().subscribe((res) => {
      if (res) {
        this.getTaxpayer();
      }
    });
  }

  openDelete(element: ITaxpayer) {
    const dialogRef = this._dialog.open(DialogDeleteComponent, {
      data: {
        title: 'Eliminar',
        message: `Esta seguro de querer eliminar este registro. "${element.nombre}"`,
      },
      width: this._dialogWidth,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this._apiTaxpayerService.delete(element.idContribuyente).subscribe(
          (res) => {
            if (res.result) {
              this.getTaxpayer();
              this._snackBar.open(res.message, '', {
                duration: this._duration,
              });
            }
          },
          (err) => {
            this._snackBar.open('Ocurrio un error inesperado.', '', {
              duration: this._duration,
            });
            console.error(err);
          }
        );
      }
    });
  }
}
